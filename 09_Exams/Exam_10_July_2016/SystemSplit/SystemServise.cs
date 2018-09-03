using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 public static  class SystemServise
    {

    public static void PrintAnalyze(List<HardwareComponent> hardware)
    {
        Console.WriteLine("System Analysis");
        Console.WriteLine($"Hardware Components: {hardware.Count}");
        Console.WriteLine($"Software Components: {GetExpressCount(hardware)+GetLightCount(hardware)}");
        Console.WriteLine($"Total Operational Memory: {hardware.Select(h => h.Memory).Sum()} / {hardware.Select(h => h.MaxMemory).Sum()}");
        Console.WriteLine($"Total Capacity Taken: {hardware.Select(h => h.Capcity).Sum()} / {hardware.Select(h => h.MaxCapacity).Sum()}");
    }
    public static void PrintFinalResult(List<HardwareComponent> hardware)
    {
        foreach (var hardComponent in hardware.Where(h=>h.Type=="Power"))
        {
            Console.Write(hardComponent);
        }
        foreach (var hardComponent in hardware.Where(h => h.Type == "Heavy"))
        {
            Console.Write(hardComponent);
        }
    }

    public static void DumpAnalyze(List<HardwareComponent> dumpedHardware)
    {
        Console.WriteLine("System Analysis");
        Console.WriteLine($"Power Hardware Components: {dumpedHardware.Where(h=>h.Type=="Power").Count()}");
        Console.WriteLine($"Heavy Hardware Components: {dumpedHardware.Where(h => h.Type == "Heavy").Count()}");
        Console.WriteLine($"Express Software Components: {GetExpressCount(dumpedHardware)}");
        Console.WriteLine($"Light Software Components: {GetLightCount(dumpedHardware)}");
        Console.WriteLine($"Total Dumped Memory: {dumpedHardware.Select(h=>h.Memory).Sum()}");
        Console.WriteLine($"Total Dumped Capacity: {dumpedHardware.Select(h => h.Capcity).Sum()}");
    }

    private  static int GetExpressCount(List<HardwareComponent> hardware)
    {
        int count = 0;
        foreach (var hardComp in hardware)
        {
            foreach (var softComp in hardComp.SoftwareComponents)
            {
                if (softComp.Type=="Express")
                {
                    count++;
                }
            }
        }

        return count;
    }
    private static int GetLightCount(List<HardwareComponent> hardware)
    {
        int count = 0;
        foreach (var hardComp in hardware)
        {
            foreach (var softComp in hardComp.SoftwareComponents)
            {
                if (softComp.Type == "Light")
                {
                    count++;
                }
            }
        }

        return count;
    }
}



