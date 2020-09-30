using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class Boat
    {
        public MenuItems MenuItems { get; set; }
        public Model.Member Member { get; set; }
        public Model.MemberList _memberList;

        public Boat(Model.MemberList memberList)
        {
            _memberList = memberList;
            SetMainMenuItems();
        }

        public void SetMainMenuItems()
        {
            MenuItems = new MenuItems("Manage your boats");

            MenuItems.Add(new MenuItem("1) List boats", () => ShowBoatsAsList(), "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Manage boats", () => ManageBoats(), "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Add boat", () => Add(), "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => { }, "0", ViewType.Member));
        }

        private void ManageBoats()
        {
            MenuItems = new MenuItems("Select boat to manage:");
            List<Model.Boat> boats = Member.BoatList.All;

            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1}) {boats[copyIndex].Name}",
                    () => ManageBoat(boats[copyIndex]),
                    $"{copyIndex + 1}",
                    ViewType.Boat
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => SetMainMenuItems(), "0", ViewType.Boat));
        }

        private void ManageBoat(Model.Boat boat)
        {
            MenuItems = new MenuItems($"{Member.Name}\n{boat.Name} - {boat.ID}");

            // TODO Make general solution for updating data over multiple classes
            MenuItems.Add(new MenuItem("1) Update type", () => { }, "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Update length", () => { }, "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Delete boat", () => { }, "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => ManageBoats(), "0", ViewType.Boat));
        }

        private void ShowBoatsAsList()
        {
            Console.Clear();
            System.Console.WriteLine(Member.Name + " - " + Member.ID + "\n");
            foreach (Model.Boat boat in Member.BoatList.All)
            {
                Console.WriteLine(boat + "\n");
            }
            System.Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }


        private void Add()
        {
            string name = SetBoatName();
            int length = SetBoatLength();
            BoatType type = SetBoatType();
            string owner = Member.Name;

            Model.Boat newBoat = new Model.Boat(type, length, name, owner);
            // _boatList.Add(newBoat);
            Member.BoatList.Add(newBoat);

            System.Console.WriteLine("\n\n" + "Member with new boat: " + Member + "\n\n");
            _memberList.UpdateMemberList();
            System.Console.WriteLine("Memberlist in BoatView: " + _memberList + "\n\n");
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
                Console.WriteLine("Length must be between 1 - 50 meters");
                response = Console.ReadLine();

            } while (!Int32.TryParse(response, out length) || length > 100 || length < 1);

            return length;

        }
        private BoatType SetBoatType()
        {
            foreach (BoatType boatType in (BoatType[])Enum.GetValues(typeof(BoatType)))
            {
                System.Console.WriteLine($"{(int)boatType}) {boatType}");
            }

            string response;
            int responseInt;

            do
            {
                response = Console.ReadKey(true).KeyChar.ToString();
            } while (!Int32.TryParse(response, out responseInt) ||
                    !Enum.IsDefined(typeof(BoatType), (BoatType)responseInt)
                    );

            return (BoatType)responseInt;
        }


    }
}