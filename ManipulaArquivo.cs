using System.Text.Json;

namespace HubDeJogos {

    
    public class ManipulaArquivo
    {
    
        public static string path = @"data/";
        public static string file = @"ranking.json";
        public static string Log = @"data/log.txt";


        public static string Arquivo(string path, string file)
        {
            return System.IO.Path.Combine(path, file);
        }

        static string fullPath = Arquivo(path, file);

        public static void LeArquivo(List<Jogador> jogadores)
        {

            // verifica existencia da pasta data
            try {
                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch (Exception e) {
                string log = @"data/log.txt";
                if (!System.IO.File.Exists(log)) {
                    using (StreamWriter sw = new StreamWriter(log)) {
                        sw.Write($"{System.DateTime.Now} ");
                        sw.WriteLine($"LeArquivo-PathExists-{e.Message}");
                    }
                }
                else {
                    using (StreamWriter sw = File.AppendText(log)) {
                        sw.Write($"{System.DateTime.Now} ");
                        sw.WriteLine($"LeArquivo-PathExists{e.Message}");
                    }
                }
            }

            // Lê arquivo e recupera ranking
            try
            {
                if (!File.Exists(fullPath)) File.Create(fullPath);
                
                string jsonString = File.ReadAllText(fullPath);

                if (!String.IsNullOrEmpty(jsonString))
                {
                    List<Jogador> listaJogadores = JsonSerializer.Deserialize<List<Jogador>>(jsonString)!;
                    listaJogadores.ForEach(jogador => jogadores.Add(jogador));
                }
                
            }
            catch (Exception e) {
                string log = @"data/log.txt";
                if (!System.IO.File.Exists(log)) {
                    using (StreamWriter sw = new StreamWriter(log)) {
                        sw.Write($"{System.DateTime.Now} ");
                        sw.WriteLine(e.Message);
                    }
                }
                else {
                    using (StreamWriter sw = File.AppendText(log)) {
                        sw.Write($"{System.DateTime.Now} ");
                        sw.WriteLine($"LeArquivo-File exists-{e.Message}");
                    }
                }
            }
        }


        public static void AtualizaArquivo(List<Jogador> jogadores)
        {            
            string jsonString = JsonSerializer.Serialize(jogadores);

            if (!File.Exists(fullPath)) System.IO.File.Create(fullPath);

            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                File.WriteAllText(fullPath, jsonString);
            }
            
        }


    }
}