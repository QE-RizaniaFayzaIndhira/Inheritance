using System;

namespace komisi_pegawai_inheritance
{
    public class KomisiPegawai : object
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomerKTP { get; }
        private decimal pendapatanKotor;
        private decimal tarifKomisi;

        public KomisiPegawai(string namaDepan, string namaBelakang, string nomerKTP, decimal pendapatanKotor, decimal tarifKomisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomerKTP = nomerKTP;
            PendapatanKotor = pendapatanKotor;
            TarifKomisi = tarifKomisi;
        }
        public decimal PendapatanKotor
        {
            get
            {
                return pendapatanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PendapatanKotor)} must be >=0");
                }
                pendapatanKotor = value;
            }
        }
        public decimal TarifKomisi
        {
            get
            {
                return tarifKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(TarifKomisi)} must be >0 and <1");
                }
                tarifKomisi = value;
            }
        }
        public decimal Pendapatan() => tarifKomisi * pendapatanKotor;
        public override string ToString() =>
                $"Gaji Pegawai = {NamaDepan}{NamaBelakang}\n" +
                $"Nomer KTP = {NomerKTP}\n" +
                $"Pendapatan Kotor = {pendapatanKotor:C}\n" +
                $"Tingkat Gaji = {tarifKomisi:F2}";
    }
    class KomisiPegawaiTest
    {
        static void Main()
        {
            var pegawai = new KomisiPegawai("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
            Console.WriteLine("Pendapatan Pegawai yang diperoleh \n");
            Console.WriteLine($"Nama Pertama = {pegawai.NamaDepan}");
            Console.WriteLine($"Nama Terakhir = {pegawai.NamaBelakang}");
            Console.WriteLine($"Nomer KTP = {pegawai.NomerKTP}");
            Console.WriteLine($"Pendapatan Kotor = {pegawai.PendapatanKotor:C}");
            Console.WriteLine($"Tingkat Gaji = {pegawai.TarifKomisi:F2}");
            Console.WriteLine($"Pendapatan = {pegawai.Pendapatan():C}");

            pegawai.PendapatanKotor = 5000.00M;
            pegawai.TarifKomisi = .1M;

            Console.WriteLine("\nInformasi Pegawai Terbaru\n");
            Console.WriteLine(pegawai);
            Console.WriteLine($"Pendapatan = {pegawai.Pendapatan():C}");
            Console.ReadLine();
        }
    }
}
