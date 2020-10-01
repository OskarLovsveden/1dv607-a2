using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class Boat
    {
        private Prompt _prompt = new Prompt();
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
            List<Model.Boat> boats = Member.BoatList;

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
            MenuItems = new MenuItems($"{Member.Name}\n{boat}");

            MenuItems.Add(new MenuItem("1) Update name", () => UpdateBoatName(boat), "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Update type", () => UpdateBoatType(boat), "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Update length", () => UpdateBoatLength(boat), "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("4) Delete boat", () => DeleteBoat(boat), "4", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => ManageBoats(), "0", ViewType.Boat));
        }

        private void ShowBoatsAsList()
        {
            _prompt.SetPromptMessage(Member.Name + " - " + Member.ID + "\n");
            _prompt.PromptShowTilClick(Member.BoatList.ToString());
        }


        private void Add()
        {
            string name = AddBoatName("Enter your boat name");
            int length = AddBoatLength("Enter your boats length");
            BoatType type = AddBoatType("Choose type of boat");

            Model.Boat newBoat = new Model.Boat(type, length, name);
            Member.BoatList.Add(newBoat);

            System.Console.WriteLine("\n\n" + "Member with new boat: " + Member + "\n\n");
            _memberList.UpdateMemberList();
            System.Console.WriteLine("Memberlist in BoatView: " + _memberList + "\n\n");
        }

        private void UpdateBoatName(Model.Boat boat)
        {
            boat.Name = AddBoatName("Change your boat name", boat.Name);
            _memberList.UpdateMemberList();
            ManageBoat(boat);
        }
        private void UpdateBoatLength(Model.Boat boat)
        {
            boat.Length = AddBoatLength("Change your boat length", boat.Length.ToString());
            _memberList.UpdateMemberList();
            ManageBoat(boat);
        }
        private void UpdateBoatType(Model.Boat boat)
        {
            boat.BoatType = AddBoatType("Change your boat type", boat.BoatType.ToString());
            _memberList.UpdateMemberList();
            ManageBoat(boat);
        }
        private void DeleteBoat(Model.Boat boat)
        {
            Member.BoatList.Remove(boat);
            _memberList.UpdateMemberList();
            ManageBoats();
        }

        private string AddBoatName(string title, string currentName = "")
        {
            _prompt.SetPromptMessage(title, currentName);
            return _prompt.PromptQuestion(
                "Name must be between 1 - 100 characters",
                (string name) => (name.Length > 100 || name.Length < 1)
            );
        }
        private int AddBoatLength(string title, string currentLength = "")
        {
            _prompt.SetPromptMessage(title);
            string result = _prompt.PromptQuestion(
                "Length must be between 1 - 20 meters",
                (string response) =>
                {
                    int length;

                    if (Int32.TryParse(response, out length))
                    {
                        return (length < 1 || length > 20);
                    }

                    return true;
                }
            );
            return Int32.Parse(result);
        }
        private BoatType AddBoatType(string title, string currentBoatType = "")
        {
            List<string> options = new List<string>();
            foreach (BoatType boatType in (BoatType[])Enum.GetValues(typeof(BoatType)))
            {
                options.Add($"{(int)boatType}) {boatType}");
            }

            _prompt.SetPromptMessage(title);
            string result = _prompt.PromptSelection(
                options,
                (string response) =>
                {
                    int responseInt;
                    return !Int32.TryParse(response, out responseInt) || !Enum.IsDefined(typeof(BoatType), (BoatType)responseInt);
                }
            );

            return (BoatType)Int32.Parse(result);
        }
    }
}