using System;

namespace View
{
    public class Start
    {
        public ViewType NextView { get; set; }
        public Start()
        {
            NextView = ViewType.Start;
        }

        public void showMenu() {
            Console.WriteLine("Choose something");
            Console.WriteLine("1) Register ");
            Console.WriteLine("2) List members ");

            switch (Console.ReadLine())
            {
                case "1":
                    NextView = ViewType.Register;
                    break;
                
                default:
                    NextView = ViewType.Start;
            }
        }

        public ViewType Run()
        {

            return NextView;
        }
    }
}