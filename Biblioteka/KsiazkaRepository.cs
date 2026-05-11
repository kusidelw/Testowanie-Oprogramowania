using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    public class KsiazkaRepository
    {
        private readonly string _connStr;

        public KsiazkaRepository(string connStr)
        {
            _connStr = connStr;
        }

        // ── ODCZYT ──────────────────────────────────────────────────────────────

        public DaneKsiazki PobierzDaneKsiazki(int ksiazkaId)
        {
            const string sql = @"
                SELECT K.Tytul, W.Nazwa AS Wydawnictwo, G.ID AS GatunekId,
                       K.LiczbaStron, K.RokWydania, K.Cena, K.Opis
                FROM KatalogKsiazek K
                JOIN Gatunki     G ON G.ID = K.GatunekID
                JOIN Wydawnictwa W ON W.ID = K.WydawnictwoID
                WHERE K.ID = @ID;";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ksiazkaId;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;
                        return new DaneKsiazki
                        {
                            Id          = ksiazkaId,
                            Tytul       = r["Tytul"].ToString(),
                            Wydawnictwo = r["Wydawnictwo"].ToString(),
                            GatunekId   = (int)r["GatunekId"],
                            LiczbaStron = (int)r["LiczbaStron"],
                            RokWydania  = (int)r["RokWydania"],
                            Cena        = (decimal)r["Cena"],
                            Opis        = r["Opis"].ToString()
                        };
                    }
                }
            }
        }

        public List<int> PobierzAutorzyKsiazki(int ksiazkaId)
        {
            const string sql = @"
                SELECT AutorID FROM KsiazkaKatalog_Autorzy WHERE KsiazkaID = @ID;";

            var wynik = new List<int>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ksiazkaId;
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) wynik.Add((int)r["AutorID"]);
                }
            }
            return wynik;
        }

        public List<Autor> PobierzAutorow(string imie, string nazwisko)
        {
            const string sql = @"
                SELECT ID, Imie, Nazwisko FROM Autorzy
                WHERE Imie LIKE @Imie AND Nazwisko LIKE @Nazwisko
                ORDER BY Nazwisko, Imie;";

            var wynik = new List<Autor>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Imie",     SqlDbType.NVarChar, 100).Value = $"%{imie}%";
                    cmd.Parameters.Add("@Nazwisko",  SqlDbType.NVarChar, 100).Value = $"%{nazwisko}%";
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                            wynik.Add(new Autor
                            {
                                ID       = (int)r["ID"],
                                Imie     = r["Imie"].ToString(),
                                Nazwisko = r["Nazwisko"].ToString()
                            });
                }
            }
            return wynik;
        }

        public List<Gatunek> PobierzGatunki(string nazwa)
        {
            const string sql = @"
                SELECT ID, Nazwa FROM Gatunki
                WHERE Nazwa LIKE @Nazwa
                ORDER BY Nazwa;";

            var wynik = new List<Gatunek>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = $"%{nazwa}%";
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                            wynik.Add(new Gatunek { ID = (int)r["ID"], Nazwa = r["Nazwa"].ToString() });
                }
            }
            return wynik;
        }

        public Dictionary<int, int> PobierzLiczbePowiazanKsiazekAutorow(List<int> autorzyIds)
        {
            if (autorzyIds == null || autorzyIds.Count == 0) return new Dictionary<int, int>();

            var parametry = BudujParametryIn(autorzyIds, "A");
            string sql = $@"
                SELECT AutorID, COUNT(*) AS Liczba
                FROM KsiazkaKatalog_Autorzy
                WHERE AutorID IN ({parametry})
                GROUP BY AutorID;";

            var wynik = new Dictionary<int, int>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DodajParametryInt(cmd, autorzyIds, "A");
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                            wynik[(int)r["AutorID"]] = (int)r["Liczba"];
                }
            }
            foreach (int id in autorzyIds.Where(id => !wynik.ContainsKey(id)))
                wynik[id] = 0;
            return wynik;
        }

        public Dictionary<int, int> PobierzLiczbePowiazanKsiazekGatunkow(List<int> gatunkiIds)
        {
            if (gatunkiIds == null || gatunkiIds.Count == 0) return new Dictionary<int, int>();

            var parametry = BudujParametryIn(gatunkiIds, "G");
            string sql = $@"
                SELECT GatunekID, COUNT(*) AS Liczba
                FROM KatalogKsiazek
                WHERE GatunekID IN ({parametry})
                GROUP BY GatunekID;";

            var wynik = new Dictionary<int, int>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DodajParametryInt(cmd, gatunkiIds, "G");
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read())
                            wynik[(int)r["GatunekID"]] = (int)r["Liczba"];
                }
            }
            foreach (int id in gatunkiIds.Where(id => !wynik.ContainsKey(id)))
                wynik[id] = 0;
            return wynik;
        }

        public int? CzyKsiazkaIstnieje(string tytul, List<int> autorzyIds)
        {
            if (autorzyIds == null || autorzyIds.Count == 0) return null;

            var parametry = BudujParametryIn(autorzyIds, "A");
            string sql = $@"
                SELECT TOP 1 K.ID FROM KatalogKsiazek K
                JOIN KsiazkaKatalog_Autorzy KA ON KA.KsiazkaID = K.ID
                WHERE K.Tytul = @Tytul AND KA.AutorID IN ({parametry});";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Tytul", SqlDbType.NVarChar, 255).Value = tytul;
                    DodajParametryInt(cmd, autorzyIds, "A");
                    object wynik = cmd.ExecuteScalar();
                    return wynik == null ? (int?)null : Convert.ToInt32(wynik);
                }
            }
        }

        // ── ZAPIS (przyjmują otwarte conn + tran) ────────────────────────────────

        public int PobierzLubDodajWydawnictwo(SqlConnection conn, SqlTransaction tran, string nazwa)
        {
            const string selectSql = "SELECT ID FROM Wydawnictwa WHERE Nazwa = @Nazwa;";
            const string insertSql = "INSERT INTO Wydawnictwa (Nazwa) OUTPUT INSERTED.ID VALUES (@Nazwa);";

            using (SqlCommand cmd = new SqlCommand(selectSql, conn, tran))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                object id = cmd.ExecuteScalar();
                if (id != null) return Convert.ToInt32(id);
            }
            using (SqlCommand cmd = new SqlCommand(insertSql, conn, tran))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                return (int)cmd.ExecuteScalar();
            }
        }

        public int DodajNowaKsiazke(SqlConnection conn, SqlTransaction tran,
            string tytul, int gatunekId, string wydawnictwo,
            int liczbaStron, int rokWydania, decimal cena, string opis)
        {
            int wydawnictwoId = PobierzLubDodajWydawnictwo(conn, tran, wydawnictwo);

            const string sql = @"
                INSERT INTO KatalogKsiazek (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
                OUTPUT INSERTED.ID
                VALUES (@Tytul, @GatunekID, @WydawnictwoID, @LiczbaStron, @RokWydania, @Cena, @Opis);";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.Add("@Tytul",         SqlDbType.NVarChar, 255).Value = tytul;
                cmd.Parameters.Add("@GatunekID",     SqlDbType.Int).Value = gatunekId;
                cmd.Parameters.Add("@WydawnictwoID", SqlDbType.Int).Value = wydawnictwoId;
                cmd.Parameters.Add("@LiczbaStron",   SqlDbType.Int).Value = liczbaStron;
                cmd.Parameters.Add("@RokWydania",    SqlDbType.Int).Value = rokWydania;
                cmd.Parameters.Add("@Cena",          SqlDbType.Decimal).Value = cena;
                cmd.Parameters.Add("@Opis",          SqlDbType.NVarChar, -1).Value = opis;
                return (int)cmd.ExecuteScalar();
            }
        }

        public void PowiazAutorowZKsiazka(SqlConnection conn, SqlTransaction tran,
            int ksiazkaId, List<int> autorzyIds)
        {
            const string sql = @"
                INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID) VALUES (@KsiazkaID, @AutorID);";

            foreach (int autorId in autorzyIds)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    cmd.Parameters.Add("@AutorID",   SqlDbType.Int).Value = autorId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AktualizujKsiazke(SqlConnection conn, SqlTransaction tran,
            int ksiazkaId, string tytul, int gatunekId, string wydawnictwo,
            int liczbaStron, int rokWydania, decimal cena, string opis,
            List<int> nowaListaAutorowIds)
        {
            int wydawnictwoId = PobierzLubDodajWydawnictwo(conn, tran, wydawnictwo);

            const string sqlUpdate = @"
                UPDATE KatalogKsiazek
                SET Tytul=@Tytul, GatunekID=@GatunekID, WydawnictwoID=@WydawnictwoID,
                    LiczbaStron=@LiczbaStron, RokWydania=@RokWydania, Cena=@Cena, Opis=@Opis
                WHERE ID=@ID;";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn, tran))
            {
                cmd.Parameters.Add("@Tytul",         SqlDbType.NVarChar, 255).Value = tytul;
                cmd.Parameters.Add("@GatunekID",     SqlDbType.Int).Value = gatunekId;
                cmd.Parameters.Add("@WydawnictwoID", SqlDbType.Int).Value = wydawnictwoId;
                cmd.Parameters.Add("@LiczbaStron",   SqlDbType.Int).Value = liczbaStron;
                cmd.Parameters.Add("@RokWydania",    SqlDbType.Int).Value = rokWydania;
                cmd.Parameters.Add("@Cena",          SqlDbType.Decimal).Value = cena;
                cmd.Parameters.Add("@Opis",          SqlDbType.NVarChar, -1).Value = opis;
                cmd.Parameters.Add("@ID",            SqlDbType.Int).Value = ksiazkaId;
                cmd.ExecuteNonQuery();
            }

            // Diff autorów: usuń tych, których nie ma w nowej liście
            if (nowaListaAutorowIds.Count > 0)
            {
                var parametry = BudujParametryIn(nowaListaAutorowIds, "A");
                string sqlDel = $@"
                    DELETE FROM KsiazkaKatalog_Autorzy
                    WHERE KsiazkaID = @KsiazkaID AND AutorID NOT IN ({parametry});";

                using (SqlCommand cmd = new SqlCommand(sqlDel, conn, tran))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    DodajParametryInt(cmd, nowaListaAutorowIds, "A");
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                const string sqlDelAll = "DELETE FROM KsiazkaKatalog_Autorzy WHERE KsiazkaID = @KsiazkaID;";
                using (SqlCommand cmd = new SqlCommand(sqlDelAll, conn, tran))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    cmd.ExecuteNonQuery();
                }
            }

            // Wstaw nowych (idempotentnie)
            const string sqlIns = @"
                INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID)
                SELECT @KsiazkaID, @AutorID
                WHERE NOT EXISTS (
                    SELECT 1 FROM KsiazkaKatalog_Autorzy
                    WHERE KsiazkaID = @KsiazkaID AND AutorID = @AutorID);";

            foreach (int autorId in nowaListaAutorowIds)
            {
                using (SqlCommand cmd = new SqlCommand(sqlIns, conn, tran))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    cmd.Parameters.Add("@AutorID",   SqlDbType.Int).Value = autorId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajEgzemplarze(SqlConnection conn, SqlTransaction tran,
            int ksiazkaId, int liczbaSztuk, int bibliotekaId)
        {
            const string sql = @"
                INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
                VALUES (@KsiazkaID, 'Dostepna', @BibID);";

            for (int i = 0; i < liczbaSztuk; i++)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    cmd.Parameters.Add("@BibID",     SqlDbType.Int).Value = bibliotekaId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajAutora(string imie, string nazwisko)
        {
            const string sql = @"
                IF NOT EXISTS (SELECT 1 FROM Autorzy WHERE Imie = @Imie AND Nazwisko = @Nazwisko)
                    INSERT INTO Autorzy (Imie, Nazwisko) VALUES (@Imie, @Nazwisko);";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Imie",     SqlDbType.NVarChar, 100).Value = imie;
                    cmd.Parameters.Add("@Nazwisko",  SqlDbType.NVarChar, 100).Value = nazwisko;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajGatunek(string nazwa)
        {
            const string sql = @"
                IF NOT EXISTS (SELECT 1 FROM Gatunki WHERE Nazwa = @Nazwa)
                    INSERT INTO Gatunki (Nazwa) VALUES (@Nazwa);";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UsunAutorow(List<int> autorzyIds)
        {
            if (autorzyIds == null || autorzyIds.Count == 0) return;

            var parametry = BudujParametryIn(autorzyIds, "A");
            string sql = $"DELETE FROM Autorzy WHERE ID IN ({parametry});";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DodajParametryInt(cmd, autorzyIds, "A");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UsunGatunki(List<int> gatunkiIds)
        {
            if (gatunkiIds == null || gatunkiIds.Count == 0) return;

            var parametry = BudujParametryIn(gatunkiIds, "G");
            string sql = $"DELETE FROM Gatunki WHERE ID IN ({parametry});";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DodajParametryInt(cmd, gatunkiIds, "G");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ── POMOCNICZE ──────────────────────────────────────────────────────────

        private static string BudujParametryIn(List<int> ids, string prefix)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < ids.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append($"@{prefix}{i}");
            }
            return sb.ToString();
        }

        private static void DodajParametryInt(SqlCommand cmd, List<int> ids, string prefix)
        {
            for (int i = 0; i < ids.Count; i++)
                cmd.Parameters.Add($"@{prefix}{i}", SqlDbType.Int).Value = ids[i];
        }
    }
}
