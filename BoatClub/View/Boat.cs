using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class Boat
    {
        private Model.BoatList _boatList = new Model.BoatList();
        public MenuItems MenuItems { get; set; }
        public Model.Member Member { get; set; }

        public Boat()
        {
            SetMainMenuItems();
        }

        public void SetMainMenuItems()
        {
            MenuItems = new MenuItems("Manage your boats");

            MenuItems.Add(new MenuItem("1) List boats", () => ListBoats(), "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Manage boats", () => ManageBoats(), "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Add boat", () => Add(), "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => {}, "0", ViewType.Member));
        }
        public void ShowBoats(Model.Member member)
        {
            List<Model.Boat> boats = _boatList.GetMembersBoats(member);
            MenuItems = new MenuItems("Boats:");
            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1})\n{boats[copyIndex].ToString()}",
                    () => ShowBoat(boats[copyIndex], member),
                    $"{copyIndex + 1}",
                    ViewType.Boat
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => {}, "0", ViewType.Member));
        }

        
        private void ListBoats()
        {
            System.Console.WriteLine("List all members boats");
        }

        private void ManageBoats()
        {
            System.Console.WriteLine("Manage members boats");
        }

        private void Add()
        {
            string name = SetBoatName();
            int length = SetBoatLength();
            BoatType type = SetBoatType();
            Model.Member owner = Member;
        
            // Model.Boat newBoat = new Model.Boat(type, length, name, owner);
        }

        private string SetBoatName()
        {
            string name;
            System.Console.WriteLine("Enter your boat name");
            do
            {
                System.Console.WriteLine("Name must be between 1 - 100 characters");
                name = Console.ReadLine();
                
            } while (name.Length > 100 || name.Length < 1);

            return name;
        }
        private int SetBoatLength()
        {
            string response;
            int length;
            System.Console.WriteLine("Enter your boats length");
            do
            {
                System.Console.WriteLine("Length must be between 1 - 50 meters");
                response = Console.ReadLine();
                
            } while (!Int32.TryParse(response, out length) || length > 100 || length < 1);

            return length;

        }
        private BoatType SetBoatType()
        {
            BoatType type = BoatType.Canoe;

            int count = 0;
            foreach (BoatType boatType in (BoatType[])Enum.GetValues(typeof(BoatType)))
            {
                count++;
                System.Console.WriteLine($"{count}) {boatType}");
            }

            do
            {

                int userSelect = Int32.Parse(Console.ReadKey(true).KeyChar.ToString());

                type = (BoatType)userSelect;
                
            } while ();            
            return type;
        }

        private void ShowBoat(Model.Boat boat, Model.Member member)
        {
            MenuItems = new MenuItems($"Member\n{boat.Name} - {boat.ID}");

            MenuItems.Add(new MenuItem("1) Update type", () => {}, "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Update length", () =>{}, "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Delete boat", () =>{}, "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => ShowBoats(member), "0", ViewType.Boat));
        }
    }
}