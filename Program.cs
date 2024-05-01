using System;
using System.Collections.Generic;
using System.Linq;

namespace Gunluk
{
    internal class Program
    {
        class Kayit
        {
            public string Metin { get; set; }
            public DateTime KayitTarihi {  get; set; }

            public Kayit (string metin)
            {
                Metin = metin;
                KayitTarihi = DateTime.Now;
            }
        }

        static List<Kayit> gunluk = new List<Kayit>();

        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("gunluk.txt");

            foreach (var item in gunluk)
            {
                writer.WriteLine(item.KayitTarihi);
                writer.WriteLine(item.Metin);           
            }
        }       

        static void VerileriYukle()
        {
            using StreamReader reader = new StreamReader("gunluk.txt");

            string satir;

            while ((satir = reader.ReadLine()) != null)
            {
                string yeniKayitTarihi = satir;
                string metin = reader.ReadLine();
                DateTime kayitTarihi;

                if (DateTime.TryParse(yeniKayitTarihi, out kayitTarihi))
                {
                    gunluk.Add(new Kayit(metin) { KayitTarihi = kayitTarihi });
                }
            }
        }

        static string Sor(string soru)
        {
            Console.Write(soru);
            return Console.ReadLine();
        }

        static void MenuGoster(bool ilkAcilisMi = false)
        {
            Console.Clear();

            if (ilkAcilisMi)
            {
                Console.WriteLine("Hoş Geldiniz!");
            }

            Console.WriteLine("Yapılacak İşlemi Seçin");
            Console.WriteLine("1. Yeni kayıt ekle");
            Console.WriteLine("2. Kayıtları listele");
            Console.WriteLine("3. Kayıtları sil");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");
            char inputSecim = Console.ReadKey().KeyChar;

            switch (inputSecim)
            {
                case '1':
                    KayitEkle();
                    break;
                case '2':
                    KayitlariListele();
                    break;
                case '3':
                    KayitlariSil();
                    break;
                case '4':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Çıkış yapılıyor...");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nHatalı Seçim Yaptınız!");
                    Console.ResetColor();
                    MenuyeDon();
                    break;
            }
        }

        static void MenuyeDon()
        {
            Console.WriteLine("\nMenüye dönmek için herhangi bir tuşa basınız.");
            Console.ReadKey(true);
            MenuGoster();
        }

        static void KayitEkle()
        {
            Console.Clear();

            DateTime bugun = DateTime.Today;
            bool gunlukteKayitVarMi = gunluk.Any(kayit => kayit.KayitTarihi.Date == bugun);

            if (gunlukteKayitVarMi)
            {
                Console.WriteLine("Bugün zaten bir kayıt eklediniz. Yeni bir kayıt daha eklemek ister misiniz (E/H)");
                string inputYeniKayit = Console.ReadLine();
                if ( inputYeniKayit == "E" || inputYeniKayit == "e")
                {
                    Console.WriteLine("Eklemek istediğiniz kayıt: ");
                    string inputKayit = Console.ReadLine();
                    gunluk.Add(new Kayit(inputKayit));
                    Console.Clear();
                    Console.WriteLine($"{inputKayit} Başarıyla eklendi!");
                    TxtKaydet();
                    MenuyeDon();
                }
                else if (inputYeniKayit == "H" || inputYeniKayit == "h")
                {
                    MenuyeDon();
                }
            }
            else
            {
                Console.WriteLine("Eklemek istediğiniz kayıt: ");
                string inputKayit = Console.ReadLine();
                gunluk.Add(new Kayit(inputKayit));
                Console.WriteLine("Günlük başarıyla eklendi!");
                TxtKaydet();
            }

            MenuyeDon();
        }       

        static void KayitlariListele()
        {
            Console.Clear();
            Console.WriteLine("Tüm Kayıtlar");
            Console.WriteLine("");

            if (gunluk.Count == 0)
            {
                Console.WriteLine("Listelenecek günlük bulunamadı.");
            }

            for (int i = 0; i < gunluk.Count; i++)
            {
                gunluk[i].KayitTarihi.ToString("ddMMyyyy");
                Console.WriteLine(gunluk[i].KayitTarihi);
                Console.WriteLine($"{i + 1}- {gunluk[i].Metin}");
                Console.WriteLine("---------------------------");

                Console.WriteLine("1. Sonraki Kayıt || 2. Düzenle || 3. Ana Menü");
                string inputSecim = Console.ReadLine();

                if (inputSecim == "1")
                {

                }
                else if (inputSecim == "2")
                {
                        Console.Clear();
                        DateTime yeniTarih = DateTime.Now;
                        string yeniMetin = Sor("Yeni metni giriniz: ");
                        gunluk[i].KayitTarihi = yeniTarih;
                        gunluk[i].Metin = yeniMetin;
                        Console.WriteLine("Metin Başarıyla Düzenlendi.");
                        TxtKaydet();
                        MenuyeDon();                    
                }
                else if (inputSecim == "3")
                {
                    MenuGoster();
                }
            }

            MenuyeDon();
        }

        static void KayitlariSil()
        {
            Console.WriteLine("\nTüm kayıtları silmek istediğinize emin misiniz? (E/H)");
            Console.Write("Seçiminiz: ");        
            string inputSilCevap = Console.ReadLine();

            if (inputSilCevap == "E" || inputSilCevap == "e")
            {
                gunluk.Clear();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Tüm kayıtlar silindi!");
                Console.ResetColor();
                TxtKaydet();
                MenuyeDon();
            }
            else
            {
                Console.WriteLine("\nMenüye dönmek için bir tuşa basınız.");
                Console.ReadKey(true);
                MenuGoster();
            }

        }

        static void Main(string[] args)
        {
            while(true)
            {
                string kullaniciAdi = "Miray";
                string kullaniciSifre = "123";

                Console.WriteLine("Kullanıcı adı giriniz: ");
                string inputKullaniciAdi = Console.ReadLine();
                Console.WriteLine("Şifre giriniz: ");
                string inputKSifre = Console.ReadLine();

                if (kullaniciAdi == inputKullaniciAdi && kullaniciSifre == inputKSifre)
                {
                    VerileriYukle();
                    MenuGoster(true);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
                    Console.ResetColor();
                }                
            }           
        }
    }
}
