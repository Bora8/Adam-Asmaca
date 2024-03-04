using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Adam_Asmaca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Adam Asmaca Uygulaması"; 

            int genislik = 120; 
            int yukseklik = 40; 

            Console.SetWindowSize(genislik, yukseklik);

            Console.WriteLine("Adam Asmacaya Hoşgeldiniz.\nOyun Formatını Belirlemek İçin 1-2'den Birini Seçiniz\n1 = Kelimeyi Konsol Belirlesin 2 = Kelimeyi Siz Giriniz Arkadaşınız Tahmin Etsin");
            int format = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            List<string> oyunlar = new List<string>
            
        {
            "TÜRKİYE", "ALMANYA", "FRANSA", "İNGİLTERE", "İTALYA",
            "İSPANYA", "PORTEKİZ", "YUNANİSTAN", "HOLLANDA", "BELÇİKA",
            "İSVİÇRE", "AVUSTURYA", "POLONYA", "ÇEKYA", "MACARİSTAN",
            "SLOVAKYA", "SLOVENYA", "HIRVATİSTAN", "BOSNA HERSEK", "KARADAĞ",
            "KOSOVA", "MAKEDONYA", "ARNAVUTLUK", "ROMANYA", "BULGARİSTAN",
            "RUSYA", "UKRAYNA", "BEYAZ RUSYA", "LİTVANYA", "LETONYA",
            "ESTONYA", "FİNLANDİYA", "İSVEÇ", "NORVEÇ", "DANİMARKA",
            "İZLANDA", "GÜRCİSTAN", "ERMENİSTAN", "AZERBAYCAN", "KAZAKİSTAN",
            "ÖZBEKİSTAN", "TÜRKMENİSTAN", "KIRGIZİSTAN", "TACİKİSTAN", "AFGANİSTAN",
            "PAKİSTAN", "HİNDİSTAN", "BANGLADEŞ", "SRİ LANKA", "NEPAL",
            "BHUTAN", "MALDİVLER", "ÇİN", "JAPONYA", "GÜNEY KORE",
            "KUZEY KORE", "MOĞOLİSTAN", "VİETNAM", "KAMBOÇYA", "LAOS",
            "TAYLAND", "MALEZYA", "SİNGAPUR", "ENDONEZYA", "FİLİPİNLER",
            "AVUSTRALYA", "YENİ ZELANDA", "KANADA", "ABD", "MEKSİKA", "ARJANTİN", 
            "ASLAN", "KAPLAN", "FİL", "ZEBRA", "AYI", "KÖPEK", "KEDİ", "KURT", 
            "PANDA", "MAYMUN", "GEYİK", "TİMSAH", "KANGURU", "TAVŞAN", "KUĞU", 
            "LEOPAR", "AKREP", "ÖRDEK", "CEYLAN", "KARTAL", "KÖPEKBALIĞI", 
            "DENİZANASI", "TAVUK", "KAPLUMBAĞA", "GORİL", "BALİNA", "YILAN", 
            "ZÜRAFA", "PENGUEN", "ARI", "SU SAMURU", "GERGEDAN", "KURBAĞA", 
            "YILDIZ BALIĞI", "ASLAN BALIĞI", "SİNCAP", "SİNEK", "KOYUN", "AT", "İNSAN", "KARTAL"
        };
            
            List<string> harfler = new List<string>
            {
                 "B", "C", "Ç", "D", "F", "G", "Ğ", "H", "J", "K", "L", "M", "N", "P", "R", "S", "Ş", "T", "V", "Y", "Z", "Q", "X", "W"
            };
            string oyun = "";

            if (format == 1)
            {
                Console.WriteLine("Kategori seçiniz. 1 = Ülke, 2 = Hayvan, 3 = Karışık");
                int kategori = int.Parse(Console.ReadLine());
                if (kategori == 1)
                {
                    int secim = random.Next(0, 71);
                    oyun = oyunlar[secim];
                }
                else if (kategori == 2)
                {
                    int secim = random.Next(71, 112);
                    oyun = oyunlar[secim];
                }
                else if (kategori == 3)
                {
                    int secim = random.Next(0, 112);
                    oyun = oyunlar[secim];
                }

            }
            if (format == 2)
            {
                Console.WriteLine("Oyunun Kelimesini Belirleyiniz.");
                string oyun1 = GetMaskedbelirlenen();
                oyun = oyun1.ToUpper();
            }
            Console.WriteLine("Başlamak İçin Enter'a Tıklayınız..");
            Console.ReadKey();
            string[] dizi = new string[oyun.Length];

            for (int i = 0; i < oyun.Length; i++)
                {
                    if (oyun[i] == ' ')
                    {
                        dizi[i] = "/"; 
                    }
                    else
                    {
                        dizi[i] = "_";
                    }
                    Console.Write(dizi[i]);
                    Console.Write(" ");
            }
            
            int hak = 10;
            int jhakki = 1;
            int j = 0;
            while (hak > 0)
                {
                YanlısTahmin:
                Console.WriteLine("\n");
                if (jhakki == 1)
                {
                    Console.WriteLine((j + 1) + ".harf tahmininizi yapın. Doğrudan Kelimeyi tahmin etmek isteseniz 'kelime' yazın. \nJoker Hakkı = " + jhakki + ". Kullanmak İçin: 'Harf Alayım'.");
                }
                else if (jhakki == 0)
                {
                    Console.WriteLine((j + 1) + ".harf tahmininizi yapın. Doğrudan Kelimeyi tahmin etmek isteseniz 'kelime' yazın. \nJoker Hakkı = " + jhakki);
                }

                string tahmin1 = Console.ReadLine();
                string tahmin = tahmin1.ToUpper();
                if (!string.IsNullOrEmpty(tahmin1))
                {
                    if (tahmin != "KELİME" && tahmin != "HARF ALAYIM")
                    {
                        if (harfler.Contains(tahmin))
                        {
                            if (oyun.Contains(tahmin))
                            {
                                for (int i = 0; i < oyun.Length; i++)
                                {
                                    if (oyun.Substring(i, 1) == tahmin)
                                    {
                                        dizi[i] = tahmin;
                                    }
                                    Console.Write(dizi[i] + " ");
                                }
                                Console.WriteLine("");
                            }
                            else
                            {
                                hak--;
                                Console.WriteLine(hak + " tane hakkınız kaldı");
                            }
                            j++;
                        }
                        else
                        {
                           Console.WriteLine("Lütfen Sadece Sessiz Harf Tahmini Yapınız.");
                           goto YanlısTahmin;
                        }

                    }
                    else if (tahmin == "KELİME")
                    {
                        Console.WriteLine("Şimdi tahmininizi yazabilirsiniz.");
                        string kelime1 = Console.ReadLine();
                        string kelime = kelime1.ToUpper();
                        if (kelime == oyun)
                        {
                            for (int i = 0; i < kelime.Length; i++)
                            {
                                dizi[i] = kelime.Substring(i, 1);
                                Console.Write(dizi[i] + " ");
                            }
                            Console.WriteLine("\nTebrikler tahmininiz doğru.");
                            Console.ReadKey();
                            break;

                        }
                        else if (kelime != oyun)
                        {
                            Console.WriteLine("Yanlış Tahmin Kaldığınız Yerden Devam Edin");
                            hak--;
                            Console.WriteLine(hak + " tane hakkınız kaldı");
                            j = j + 1;
                            goto YanlısTahmin;
                        }
                    }
                    else if(tahmin == "HARF ALAYIM")
                    {
                        if (jhakki == 1)
                        {   
                            yeniHarf:
                            int joker = random.Next(0,oyun.Length);
                            dizi[joker] = oyun.Substring(joker, 1);
                            if (dizi[joker] == "")
                            {
                                goto yeniHarf;
                            }
                            else
                            {
                                for (int i = 0; i < oyun.Length; i++)
                                {
                                    Console.Write(dizi[i] + " ");
                                }
                                jhakki--;
                            } 
                        }
                        else
                        {
                            Console.WriteLine("Tahmin Hakkınız Bulunmamakta.");
                            goto YanlısTahmin;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen Bir Harf Giriniz.");
                    goto YanlısTahmin;
                }
            }
            if (hak == 0)
            {
                Console.WriteLine("Tahmin hakkınız bitti oyunu kaybettiniz.");
                Console.WriteLine(oyun);
                Console.ReadKey();
            }
        }
        static string GetMaskedbelirlenen()
        {
            string belirlenen = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (!char.IsControl(key.KeyChar))
                {
                    Console.Write("*");
                    belirlenen += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && belirlenen.Length > 0)
                {
                    Console.Write("\b \b");
                    belirlenen = belirlenen.Substring(0, belirlenen.Length - 1);
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return belirlenen;
        }
    }
}
