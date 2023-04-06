using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    public class lopHoc
    {
        public List<giangVien> teachers;
        public List<sinhVien> students;
    }
    public enum TeacherType
    {
        Main = 0,
        Support = 1,
        AcademicStaff = 2,
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
    [Serializable]
    public class giangVien
    {
        public int id;
        public string name;
        public int age;
        public int gender;
        public int type;
        public TeacherType teacherType
        {
            get { return (TeacherType)type; }
            set { type = (int)value; }
        }
        public Gender sex
        {
            get { return (Gender)gender; }
            set { gender = (int)value; }
        }
    }
    [Serializable]
    public class sinhVien
    {
        public int id;
        public string name;
        public int age;
        public int gender;
        public int diemThiCSharp;
        public Gender sex
        {
            get { return (Gender)gender; }
            set { gender = (int)value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            lopHoc lopU22_2 = new lopHoc();
            lopU22_2.teachers = new List<giangVien>();
            lopU22_2.students = new List<sinhVien>();
            lopU22_2.teachers.Add(new giangVien() { id = 1, name = "Bien", age = 33, sex = Gender.Male, teacherType = TeacherType.Main });
            lopU22_2.students.Add(new sinhVien() { id = 1, name = "Hieu", age = 20, sex = Gender.Female, diemThiCSharp = 18 });
            lopU22_2.students.Add(new sinhVien() { id = 2, name = "Han1", age = 20, sex = Gender.Female, diemThiCSharp = 201 });
            lopU22_2.students.Add(new sinhVien() { id = 3, name = "Han12", age = 20, sex = Gender.Female, diemThiCSharp = 2 });
            lopU22_2.students.Add(new sinhVien() { id = 4, name = "Nung", age = 20, sex = Gender.Female, diemThiCSharp = 8 });

            Console.WriteLine("Truoc khi sap xep:");
            foreach (var student in lopU22_2.students)
            {
                Console.WriteLine ("Sinh Vien so: " + student.id + ", Ten la: " + student.name +  ", Tuoi:" + student.age + ", Gioi tinh:" + student.gender + ", Diem thi:" + student.diemThiCSharp);
            }
            sinhVien t = new sinhVien();
            Console.WriteLine(" Sau khi sap xep: ");
            for (int p = 0; p <= lopU22_2.students.Count - 2; p++)
            {
                for (int i = 0; i <= lopU22_2.students.Count - 2; i++)
                {
                    if (lopU22_2.students[i].diemThiCSharp < lopU22_2.students[i + 1].diemThiCSharp)
                    {
                        t = lopU22_2.students[i + 1];
                        lopU22_2.students[i + 1] = lopU22_2.students[i];
                        lopU22_2.students[i] = t;
                    }
                }
            }
            foreach (var student in lopU22_2.students)
            {
                Console.WriteLine("Sinh Vien so: " + student.id + ", Ten la: " + student.name + ", Tuoi:" + student.age + ", Gioi tinh:" + student.gender + ", Diem thi:" + student.diemThiCSharp);
            }



            FileStream fs = new FileStream("lopU22_2.txt", FileMode.Create);

            //Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, lopU22_2);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
                Console.WriteLine("success!");
            }
        }
    }
}
