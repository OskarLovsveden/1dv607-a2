using System;

namespace View
{
    public class BoatList
    {
        public ViewType NextView { get; set; }

        private Model.BoatList _boatList = new Model.BoatList();

        public BoatList()
        {
            NextView = ViewType.Start;

            // Temp code - Get boats from database
            Model.Boat Boat1 = new Model.Boat(BoatType.Sailboat, 5, "boat1", "1");
            Model.Boat Boat2 = new Model.Boat(BoatType.Canoe, 10, "boat2", "2");
            Model.Boat Boat3 = new Model.Boat(BoatType.Motorsailer, 15, "boat3", "3");
            _boatList.Add(Boat1);
            _boatList.Add(Boat2);
            _boatList.Add(Boat3);
            // Temp code end
        }

        private void ShowMenu()
        {
            bool show = true;

            while (show)
            {
                PrintMenuMessage();
                show = GetMenuChoice();
            }
        }

        private void PrintMenuMessage()
        {
            Console.Clear();
            foreach (Model.Boat boat in _boatList.Boats)
            {
                System.Console.WriteLine(boat.Name);
                Console.WriteLine(boat.ToString());
                System.Console.WriteLine("----");
            }
        }

        private bool GetMenuChoice()
        {
            bool show = true;
            switch (Console.ReadLine())
            {
                case "1":
                    NextView = ViewType.Boat;
                    show = false;
                    break;
                case "0":
                    NextView = ViewType.Start;
                    show = false;
                    break;
                default:
                    break;
            }
            return show;
        }

        public ViewType Run()
        {
            ShowMenu();
            return NextView;
        }
    }
}