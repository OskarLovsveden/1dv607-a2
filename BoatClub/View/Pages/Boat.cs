using System;
using System.Collections.Generic;
using Model.Menu;

namespace View.Pages
{
    public class Boat
    {
        private Prompt _prompt = new Prompt();
        private Model.Member _member;
        private MenuCollection _menuCollection;

        public MenuCollection MenuCollection { get => _menuCollection; }

        public Model.Member Member
        {
            get => _member;
            set => _member = value;
        }
        public Model.MemberList _memberList;

        public Boat(Model.MemberList memberList)
        {
            _memberList = memberList;
            SetMainMenuCollection();
        }

        public void SetMainMenuCollection()
        {
            MenuCollection mc = new MenuCollection($"Manage boats");

            mc.Add(new MenuItem($"{mc.CurrentActionKey}) List boats", () => ShowBoatsAsList(), mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Update/Delete boat", () => ManageBoats(), mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Add boat", () => Add(), mc.CurrentActionKey, ViewType.Boat));
            mc.AddGoBackMenuItem(() => { }, ViewType.Member);

            _menuCollection = mc;
        }

        private void ManageBoats()
        {
            MenuCollection mc = new MenuCollection("Select boat to manage:");
            IReadOnlyList<Model.Boat> boats = Member.BoatList;

            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                mc.Add(new MenuItem(
                    $"{mc.CurrentActionKey}) {boats[copyIndex].Name}",
                    () => ManageBoat(boats[copyIndex]),
                    mc.CurrentActionKey,
                    ViewType.Boat
                ));
            }

            mc.AddGoBackMenuItem(() => SetMainMenuCollection(), ViewType.Boat);

            _menuCollection = mc;
        }

        private void ManageBoat(Model.Boat boat)
        {
            MenuCollection mc = new MenuCollection($"{Member.Name}\n{boat}");

            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Update name", () => UpdateBoatName(boat), mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Update type", () => UpdateBoatType(boat), mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Update length", () => UpdateBoatLength(boat), mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Delete boat", () => DeleteBoat(boat), mc.CurrentActionKey, ViewType.Boat));
            mc.AddGoBackMenuItem(() => ManageBoats(), ViewType.Boat);

            _menuCollection = mc;
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
            Member.AddBoat(newBoat);

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
            Member.RemoveBoat(boat);
            _memberList.UpdateMemberList();
            ManageBoats();
        }

        private string AddBoatName(string title, string currentName = "")
        {
            _prompt.SetPromptMessage(title, currentName);
            return _prompt.PromptQuestion(
                // TODO Remove string dependency and magic numbers
                "Name must be between 1 - 40 characters",
                (string name) => (name.Length > 40 || name.Length < 1)
            );
        }

        private int AddBoatLength(string title, string currentLength = "")
        {
            _prompt.SetPromptMessage(title);
            string result = _prompt.PromptQuestion(
                // TODO Remove string dependency
                "Length must be between 1 - 20 meters",
                (string response) =>
                {
                    int length;

                    if (Int32.TryParse(response, out length))
                    {
                        // TODO Remove magic numbers
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

        private string BoatListToString(IReadOnlyList<Model.Boat> boatList)
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