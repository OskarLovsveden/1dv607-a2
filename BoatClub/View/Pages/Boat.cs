using System;
using System.Collections.Generic;
using Model.Menu;

namespace View.Pages
{
    public class Boat
    {
        private Prompt _prompt = new Prompt();
        public MenuCollection MenuCollection { get; set; }
        public Model.Member Member { get; set; }
        public Model.MemberList _memberList;

        public Boat(Model.MemberList memberList)
        {
            _memberList = memberList;
            SetMainMenuCollection();
        }

        public void SetMainMenuCollection()
        {
            MenuCollection = new MenuCollection($"Manage boats");

            MenuCollection.Add(new MenuItem("1) List boats", () => ShowBoatsAsList(), "1", ViewType.Boat));
            MenuCollection.Add(new MenuItem("2) Update boat information", () => ManageBoats(), "2", ViewType.Boat));
            MenuCollection.Add(new MenuItem("3) Add boat", () => Add(), "3", ViewType.Boat));
            MenuCollection.Add(new MenuItem("0) Go back", () => { }, "0", ViewType.Member));
        }

        private void ManageBoats()
        {
            MenuCollection = new MenuCollection("Select boat to manage:");
            List<Model.Boat> boats = Member.BoatList;

            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                MenuCollection.Add(new MenuItem(
                    $"{copyIndex + 1}) {boats[copyIndex].Name}",
                    () => ManageBoat(boats[copyIndex]),
                    $"{copyIndex + 1}",
                    ViewType.Boat
                ));
            }

            MenuCollection.Add(new MenuItem("0) Go Back", () => SetMainMenuCollection(), "0", ViewType.Boat));
        }

        private void ManageBoat(Model.Boat boat)
        {
            MenuCollection = new MenuCollection($"{Member.Name}\n{boat}");

            MenuCollection.Add(new MenuItem("1) Update name", () => UpdateBoatName(boat), "1", ViewType.Boat));
            MenuCollection.Add(new MenuItem("2) Update type", () => UpdateBoatType(boat), "2", ViewType.Boat));
            MenuCollection.Add(new MenuItem("3) Update length", () => UpdateBoatLength(boat), "3", ViewType.Boat));
            MenuCollection.Add(new MenuItem("4) Delete boat", () => DeleteBoat(boat), "4", ViewType.Boat));
            MenuCollection.Add(new MenuItem("0) Go back", () => ManageBoats(), "0", ViewType.Boat));
        }

        private void ShowBoatsAsList()
        {
            _prompt.SetPromptMessage(Member.Name + " - " + Member.ID + "\n");
            _prompt.PromptShowTilClick(BoatListToString(Member.BoatList));
        }

        private void Add()
        {
            string name = AddBoatName("Enter boat name");
            int length = AddBoatLength("Enter boat length");
            BoatType type = AddBoatType("Choose type of boat");

            Model.Boat newBoat = new Model.Boat(type, length, name);
            Member.BoatList.Add(newBoat);

            System.Console.WriteLine("\n\n" + "Member with new boat: " + Member + "\n\n");
            _memberList.UpdateMemberList();
            System.Console.WriteLine("Memberlist in BoatView: " + _memberList + "\n\n");
        }

        private void UpdateBoatName(Model.Boat boat)
        {
            boat.Name = AddBoatName("Change boat name", boat.Name);
            _memberList.UpdateMemberList();
            ManageBoat(boat);
        }
        private void UpdateBoatLength(Model.Boat boat)
        {
            boat.Length = AddBoatLength("Change boat length", boat.Length.ToString());
            _memberList.UpdateMemberList();
            ManageBoat(boat);
        }
        private void UpdateBoatType(Model.Boat boat)
        {
            boat.BoatType = AddBoatType("Change boat type", boat.BoatType.ToString());
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

        private string BoatListToString(List<Model.Boat> boatList)
        {
            string boats = "";

            if (boatList.Count == 0) return "Member has no boats yet";

            foreach (Model.Boat boat in boatList)
            {
                boats += $"Name: {boat.Name}, Type: {boat.BoatType}, Length: {boat.Length}\n";
            }

            return boats;
        }
    }
}