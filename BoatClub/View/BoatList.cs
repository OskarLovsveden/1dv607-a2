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

            Model.Boat Boat1 = new Model.Boat(BoatType.Sailboat, 5, "boat1", "1");
            Model.Boat Boat2 = new Model.Boat(BoatType.Canoe, 10, "boat2", "2");
            Model.Boat Boat3 = new Model.Boat(BoatType.Motorsailer, 15, "boat3", "3");
            _boatList.add(Boat1);
            _boatList.add(Boat2);
            _boatList.add(Boat3);
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
            foreach (Model.Boat boat in _boatList)
            {

            }
        }

        private bool GetMenuChoice()
        {
            bool show = true;
            switch (Console.ReadLine())
            {
                case "1":
                    ShowVerboseList();
                    show = false;
                    break;
                case "2":
                    ShowCompactList();
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