using System.Collections.Generic;

namespace Gunluk
{
    internal class Program
    {
        static List<string> gunluk = new List<string>();

        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("gunluk.txt");

            foreach (var item in gunluk)
            {                
                writer.WriteLine(item);
            }
        }       

        static void VerileriYukle()
        {
            using StreamReader reader = new StreamReader("gunluk.txt");

            string satir;

            while ((satir = reader.ReadLine()) != null)
            {
                gunluk.Add(satir);
            }
        }

        static void MenuGoster(bool ilkAcilisMi = false)
        {
            Console.Clear();

            if (ilkAcilisMi)
            {
                Console.WriteLine("Hoş Geldiniz");
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

                    break;
                default:
                    Console.WriteLine("\nHatalı Seçim Yaptınız!");
                    MenuyeDon();
                    break;
            }
        }

        static void MenuyeDon()
        {
            Console.WriteLine("\nMenüye dönmek için bir tuşa basınız.");
            Console.ReadKey(true);
            MenuGoster();
        }

        //static void ZamaniKaydet()
        //{
        //    DateTime bugun = DateTime.Now;
        //    Console.WriteLine("GÜnlüğü kaydettiğin tarih ve saat: " + bugun + ".");
        //}

        static void KayitEkle()
        {
            Console.Clear();
            Console.WriteLine("Eklemek istediğiz kayıt: ");
            string inputKayit = Console.ReadLine();
            //ZamaniKaydet();
            gunluk.Add(inputKayit);
            Console.WriteLine("Günlük başarıyla eklendi!");
            TxtKaydet();
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
                //ZamaniKaydet();
                Console.WriteLine($"{i + 1}- {gunluk[i]}");
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
                Console.WriteLine("Tüm kayıtlar silindi!");
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
            VerileriYukle();
            MenuGoster(true);
        }
    }
}
