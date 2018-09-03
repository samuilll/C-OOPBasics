using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter
{

    public static void ExecuteCommands(SystemState systemState)
    {
        var hardware = systemState.Hardware;
        var dumpedHardware = systemState.DumpedHardware;

        while (true)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (input[0] == "System")
            {
                break;
            }
            ExecuteCurrentCommand(hardware, dumpedHardware, input);
        }

        SystemServise.PrintFinalResult(hardware);
    }

    private static void ExecuteCurrentCommand(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        switch (input.Count)
        {
            case 1:
                {
                    PrintWantedData(hardware, dumpedHardware, input);
                    break;
                }
            case 2:
                {
                    DumpOperating(hardware, dumpedHardware, input);
                    break;
                }
            case 3:
                {
                    RemoveSoftware(hardware, input);
                    break;
                }
            case 4:
                {
                    AddHardware(hardware, input);
                    break;
                }
            case 5:
                {
                    AddSoftware(hardware, input); break;
                }
            default:
                break;
        }
    }

    private static void DumpOperating(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        if (input[0] == "Dump")
        {
            DumpHardware(hardware, dumpedHardware, input);
        }
        else if (input[0] == "Restore")
        {
            RestoreHardware(hardware, dumpedHardware, input);
        }
        else
        {
            DestroyHardware(hardware, dumpedHardware, input);
        }
    }

    private static void PrintWantedData(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        if (input[0] == "Analyze")
        {
            SystemServise.PrintAnalyze(hardware);
        }
        else
        {
            SystemServise.DumpAnalyze(dumpedHardware);
        }
    }

    private static void AddHardware(List<HardwareComponent> hardware, List<string> input)
    {
        HardwareComponent currentHardwareComponent = Hardwarefactory.CreateHardware(input);
        hardware.Add(currentHardwareComponent);
    }

    private static void RemoveSoftware(List<HardwareComponent> hardware, List<string> input)
    {
        string hardwareName = input[1];
        string softwareName = input[2];

        if (hardware.Any(h => h.Name == hardwareName))
        {
            var currentHardComponent = hardware.First(h => h.Name == hardwareName);

            if (currentHardComponent.SoftwareComponents.Any(s => s.Name == softwareName))
            {
                currentHardComponent.RemoveSoftware(softwareName);
            }
        }
    }

    private static void DestroyHardware(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        string hardwareToRestoreName = input[1];

        if (dumpedHardware.Any(h => h.Name == hardwareToRestoreName))
        {
            dumpedHardware.Remove(dumpedHardware.First(h => h.Name == hardwareToRestoreName));
        }
    }

    private static void RestoreHardware(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        string hardwareToRestoreName = input[1];

        if (dumpedHardware.Any(h => h.Name == hardwareToRestoreName))
        {
            HardwareComponent hardwareToRestore = dumpedHardware.First(h => h.Name == hardwareToRestoreName);

            dumpedHardware.Remove(dumpedHardware.First(h => h.Name == hardwareToRestoreName));

            hardware.Add(hardwareToRestore);
        }
    }

    private static void DumpHardware(List<HardwareComponent> hardware, List<HardwareComponent> dumpedHardware, List<string> input)
    {
        string hardwareToRemoveName = input[1];

        if (hardware.Any(h => h.Name == hardwareToRemoveName))
        {
            HardwareComponent hardwareToRemove = hardware.First(h => h.Name == hardwareToRemoveName);

            hardware.Remove(hardware.First(h => h.Name == hardwareToRemoveName));

            dumpedHardware.Add(hardwareToRemove);
        }
    }

    private static void AddSoftware(List<HardwareComponent> hardware, List<string> input)
    {
        SoftwareComponent currentSoftwareComponent = SoftwareFactory.CreateSoftware(input);
        if (hardware.Any(h => h.Name == currentSoftwareComponent.HardwareComponent))
        {
            var currenthardComponent = hardware.First(h => h.Name == currentSoftwareComponent.HardwareComponent);
            if (currenthardComponent.CanTakeSoftware(currentSoftwareComponent))
            {
                currenthardComponent.AddSoftwareComponent(currentSoftwareComponent);
            }

        }
    }

}

