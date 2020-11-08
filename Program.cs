using BTH_6;
using System;
using System.Security.Authentication.ExtendedProtection;

namespace BTH_6
{
    // bai 1
    abstract class NhanVien
    {
        protected string hoten;
        protected string diachi;
        protected DateTime ngaysinh;
        public NhanVien()
        {
            hoten = diachi = "";
            ngaysinh = DateTime.Now;
        }
        public NhanVien(string hoten, string diachi, DateTime ngaysinh)
        {
            this.hoten = hoten;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap Ho ten:");
            hoten = Console.ReadLine();
            Console.Write("Nhap dia chi:");
            diachi = Console.ReadLine();
            ngaysinh = DateTime.Parse(Console.ReadLine());
        }
        public virtual void Hien()
        {
            Console.WriteLine("{0}\t{1}\{2}", hoten, diachi, ngaysinh);

        }
        public abstract double TinhLuong();
        public class NVSX : NhanVien
        {
            private int ssp;
            public NVSX() : base() { ssp = 0; }
            public NVSX(string hoten, string diachi, DateTime ngaysinh, int ssp) : base(hoten, diachi, ngaysinh) { this.ssp = ssp}
            public override void Nhap()
            {
                Console.WriteLine("Nhap thong tin cho nhan vien san xuat");
                base.Nhap();
                Console.Write("Nhap so san pham:");
                ssp = int.Parse(Console.ReadLine());
            }
            public override void Hien()
            {
                Console.WriteLine("Thong tin luong cua nhan vien san xuat");
                base.Hien();
                Console.WriteLine("So san pham" + ssp);
                Console.WriteLine("Luong:" + TinhLuong());
            }
            public override double Tinhluong()
            {
                return ssp * 20000;
            }
        }
    }
    public class NVCN : NhanVien
    {
        private int scn;
        public NVCN() : base() { scn = 0; }
        public NVCN(string hoten, string diachi, DateTime ngaysinh, int scn) : base(hoten, diachi, ngaysinh) { this.scn = scn; }
        public override void Nhap()
        {
            Console.WriteLine("Nhap thong tin cho nhan vien cong nhat");
            base.Nhap();
            Console.Write("Nhap so ngay cong:");
            scn = int.Parse(Console.ReadLine());
        }
        public override void Hien()
        {
            Console.WriteLine("Thong tin nhan vien cong nhat");
            base.Hien();
            Console.WriteLine("So ngay cong" + scn);
            Console.WriteLine("Luong:" + TinhLuong());
        }
        public override double TinhLuong()
        {
            return scn * 50000;
        }
    }
    public class NVQL : NhanVien
    {
        private double hsl;
        private static int luongcoban = 1050;
        public NVQL() : base() { hsl = 2.34; }
        public NVQL(string hoten, string diachi, DateTime ngaysinh, int hsl) : base(hoten, diachi, ngaysinh) { this.hsl = hsl; }
        public static int Luongcoban
        {
            get { return luongcoban; }
            set
            {
                if (value > 1050) luongcoban = value;
            }
        }
        public override void Nhap()
        {
            Console.WriteLine("Nhap thong tin cho nhan vian quan ly");
            base.Nhap();
            Console.Write("Nhap he so luong:");
            hsl = double.Parse(Console.ReadLine());
        }
        public override void Hien()
        {
            Console.WriteLine("Thong tin luong cua nhan vien quan ly");
            base.Hien();
            Console.WriteLine("He so luong" + hsl);
            Console.WriteLine("Luong:" + TinhLuong());
        }
        public override double TinhLuong()
        {
            return hsl * luongcoban;
        }
    }
    class QuanLy
    {
        private NhanVien[] ds;
        private int snv;
        public void Nhap()
        {
            Console.Write("Nhap so nhan vien ");
            svn = int.Parse(Console.ReadLine());
            ds = new NhanVien[svn];
            for (int i = 0; i < snv; ++i)
            {
                Console.Write("ban muon nhap thong tin cho nahn vien quan ly(Q),Cong nhat(C),san xuat(S)");
                char ch = char.Parse(Console.ReadLine());
                switch (char.ToUpper(ch))
                {
                    case 'Q': ds[i] = new NVQL(); ds[i].Nhap(); break;
                    case 'C': ds[i] = new NVQL(); ds[i].Nhap(); break;
                    case 'S': ds[i] = new NVQL(); ds[i].Nhap(); break;

                }
            }
        }
        public void Hien()
        {
            for (int i = 0; i < snv; ++i)
                ds[i].Hien();
        }
    }
}
class bai1
{
    static void Main()
    {
        QuanLy t = new QuanLy();
        t.Nhap();
        t.Nhap();
        Console.ReadKey();
    }
}
// bai 3
class canbo
{
    private string hoten;
    private string quequan;
    private double hesoluong;
    private static int luongcoban = 1150;
    public canbo()
    {
        hoten = quequan = "";
        hesoluong = 2.34;
    }
    public canbo(string hoten,string quequan,double hesoluong)
    {
        this.hoten = hoten;
        this.quequan = quequan;
        this.hesoluong = hesoluong;
    }
    public static int Luongcoban
    {
        get { return luongcoban; }
        set
        {
            if (value > 1050) luongcoban = value;
        }
    }
    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten:");
        hoten = Console.ReadLine();
        Console.Write("Nhap que quan:");
        quequan = Console.ReadLine();
        Console.Write("Nhap he so luong:");
        hesoluong = double.Parse(Console.ReadLine());
    }
    public virtual void TinhLuong ()
    {
        return hesoluong * luongcoban; 
    }
    public virtual void Hien()
    {
        Console.WriteLine("Ho ten:" + hoten);
        Console.WriteLine("Que quan:" + quequan);
        Console.WriteLine("He so luong :" + hesoluong);
    }

}
class GiaoVien:canbo
{
    private double phucap;
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin cho giao vien");
        base.Nhap();
        Console.Write("Nhap phu cap:");
        phucap = double(Console.ReadLine());
    }
    public override void TinhLuong()
    {
       return base.TinhLuong()+ phucap;
    }
    public override void Hien()
    {
        Console.WriteLine("Thong tin ve Giao vien");
        base.Hien();
        Console.WriteLine(" Phu cap:" + phucap);
        Console.WriteLine("Luong:" + TinhLuong());
    }
}
class HanhChinh:canbo
{
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin nhan vien hanh chinh:");
        base.Nhap();
    }
    public override void Nhap()
    {
        Console.WriteLine("Thong tin ve HC:");
        base.Hien();
        Console.WriteLine("Luong:" + TinhLuong());
    }
}
class QL
{
    private canbo[] ds;
    private int scb;
    public void Nhap()
    {
        Console.Write("Nhap so can bo:");
        scb = int.Parse(Console.ReadLine());
        ds = new canbo[scb];
        for(int i=0;i<scb;++i)
        {
            Console.Write("Can bo ban muon nhap la GV(V) hay HC(H):");
            char ch = char.Parse(Console.ReadLine());
            switch(char.ToUpper(ch))
            {
                case 'V':ds[i] = new GiaoVien();ds[i].Nhap();break;
                case 'H':ds[i] = new HanhChinh();ds[i].Nhap();break;

            }
        }
    }
    public void HienLuongMax()
    {
        double mx;
        mx = double.MinValue;
        for (int i = 0; i < scb; ++i)
            if (ds[i] is GiaoVien && mx < ds[i].TinhLuong()) mx = ds[i].TinhLuong();
        Console.WriteLine("Luong cao nhat cua Gv la:" + mx);
        mx = double.MinValue;
        for(int i=0;i<scb;++i)
            if (ds[i] is HanhChinh && mx < ds[i].TinhLuong()) mx = ds[i].TinhLuong();
        Console.WriteLine("Luong cao nhat cua HC la:" + mx);
        mx = double.MinValue;
    }
    public void Hien1()
    {
        Console.WriteLine("Thong tin ve cac can bo");
        for (int i = 0; i < scb; ++i)
            ds[i].Hien();
    }
    public void Hien2()
    {
        Console.WriteLine("Danh sach luong GV");
        for (int i = 0; i < scb; ++i)
            if (ds[i] is GiaoVien)
                ds[i].Hien();
        Console.WriteLine("Danh sach luong HC");
        for (int i = 0; i < scb; ++i)
            if (ds[i] is HanhChinh)
                ds[i].Hien();
    }
}
class Bai3
{
    static void Main()
    {
        QL t = new QL();
        t.Nhap();
        t.Hien1();
        t.Hien2();
        Console.ReadLine();
    }
}
