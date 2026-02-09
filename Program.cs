Wizard wizardA = new Wizard("Gokjo", 40, 15, 10);
Wizard wizardB = new Wizard("Sukini", 45, 15, 10);

Console.WriteLine("Permainan Dimulai... \n");
wizardA.ShowStats();
wizardB.ShowStats();

//wizardA.Attack(wizardB); //itu yang di dalam parameter itu targetnya
//wizardB.Attack(wizardA);
//wizardA.Attack(wizardB);
//wizardA.Heal(wizardA);
string pilihan ="";

while (wizardA.Energy > 0 && wizardB.Energy > 0)
{
    Console.WriteLine("Pilih salah satu aksi berikut : ");
    Console.WriteLine($"1. {wizardA.Name} menyerang {wizardB.Name}");
    Console.WriteLine($"2. {wizardB.Name} menyerang {wizardA.Name}");
    Console.WriteLine($"3. {wizardA.Name} melakukan heal");
    Console.WriteLine($"4. {wizardB.Name} melakukan heal");

    Console.Write("\nMasukkan pilihanmu (1/2/3/4) : ");
    pilihan = Console.ReadLine();
    if (pilihan == "1")
    {
        wizardA.Attack(wizardB);
    }
    else if (pilihan == "2")
    {
        wizardB.Attack(wizardA);
    }
    else if (pilihan == "3")
    {
        wizardA.Heal(wizardA);
    }
    else if (pilihan == "4")
    {
        wizardB.Heal(wizardB);
    }
    else
    {
        Console.WriteLine("Pilihan tidak valid!!");
    }
}

Console.WriteLine("Permainan Berakhir... \n");
wizardA.ShowStats();
wizardB.ShowStats();

if (wizardA.Energy > wizardB.Energy)
{
    Console.WriteLine($"{wizardA.Name} memenangkan duel");
}
else
{
    Console.WriteLine($"{wizardB.Name} memenangkan duel");
}

public class Wizard
{
    //deklarasi field
    public string Name;
    public int Energy;
    public int Damage;
    public int heal;

    //deklarasi constructor
    public Wizard(string name, int damage, int v, int heal) //() itu dalamnya buat ngisi field
    {
        Name = name; //Name itu fieldnya, name kecil itu parameternya
        Energy = 100; // Energy gada parameter di public wizard atas tu, karena udah pasti di set 100
        Damage = damage;
    }

    public void ShowStats()
    {
        Console.WriteLine("Statistik Wizard");
        Console.WriteLine($"Nama : {Name}, Energi : {Energy} \n");
    }

    public void Attack(Wizard wizardLawanObj) // Attack karena membutuhkan objek lain untuk dimanipulasi disini, maka kita butuh objek lain untuk dimanipulasi dalam situasi ini itu WizardLawanObj
                                              // Kan ada 2 object, wizard a dan b, nah pas wizard a nyerang, wizard b darahnya kan ngurang, dalam proses attack itu ada step untuk mengurangi energi dari objek lain
                                              //nah jadi waktu kita panggil attack, kita kirimkan object kedua/yang mau diserang, karena tipe kita bukan int dan sebagainya, kita pakai object jadi kita harus class object formatnya gitu
    {
        // mengurangi energi wizardlawanObj sebesar damage
        wizardLawanObj.Energy -= Damage;
        Console.WriteLine($"{Name} menyerang {wizardLawanObj.Name}");
        Console.WriteLine($"Sisa Energi {wizardLawanObj.Name} adalah {wizardLawanObj.Energy}");
    }

    // method heal
    public void Heal(Wizard wizardA)
    {
        Energy += 5;

        if ( Energy <= 100 )
        {
            Console.WriteLine($"{Name} melakukan heal, energi bertambah sebanyak {Energy}");
        }
        else
        {
            Energy = 100;
            Console.WriteLine("Sudah mencapai energi maksimum");
        }
    }
}
