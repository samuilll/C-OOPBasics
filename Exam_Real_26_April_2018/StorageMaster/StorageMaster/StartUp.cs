using System;

namespace StorageMaster
{
  public  class StartUp
    {
         static void Main()
        {
            StorageMaster storageMaster = new StorageMaster();

            Engine engine = new Engine(storageMaster);

            engine.Run();
        }
    }
}
