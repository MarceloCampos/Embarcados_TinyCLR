// adicionar o 'GHIElectronics.TinyCLR.Devices.Gpio' abaixo via Nuget: menu Projeto -> Gerenciar Pacotes do Nuget
// IMPORTANTE: 
//  1. deixar tickado-selecionada a opção "Incluir pré lançamento" logo ao lado do texto de procura do pacote Nuget
//  2. A versão tem de ser a compatível com a do firmware da sua placa, para saber qual versão na placa abra o arquivo "packages.config" fica nos arquivos de projeto
//  caso necessário atualizar, o que pode acontecer mesmo com placas novas:
// https://docs.ghielectronics.com/software/tinyclr/tinyclr-config.html

using System.Threading;
using GHIElectronics.TinyCLR.Devices.Gpio;


namespace Embarcados_TinyCLR
{
    class Program
    {
        static void Main()
        {
            // Instância objeto nomeado 'OnBoardLed' como ~LED1 interno da placa como saída
            var OnBoardLed = GpioController.GetDefault().OpenPin(GHIElectronics.TinyCLR.Pins.FEZ.GpioPin.Led1);

            // coloca esse pino conectado ao led como saída
            OnBoardLed.SetDriveMode(GpioPinDriveMode.Output);

            // Escreve na janela Saída do Visual Studio (menu Exibir : Saída)
            System.Diagnostics.Debug.WriteLine("> Iniciado .NET MicroFramework OK !");

            while (true)
            {
                // Pisca Led
                OnBoardLed.Write(GpioPinValue.High);
                Thread.Sleep(500);

                OnBoardLed.Write(GpioPinValue.Low);
                Thread.Sleep(500);
            }

        }
    }
}
