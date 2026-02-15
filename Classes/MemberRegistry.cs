using System.Collections.Generic;

namespace LibrarySystem.Classes
{
    public class MemberRegistry
    {
        // Stores members by their ID 
        private readonly Dictionary<string, Member> _membersById = new();

        // Adds or replaces a member
        public void AddMember(Member member)
        {
            _membersById[member.MemberId] = member;
        }

        // Finds a member by ID, returns null if not found
        public Member? FindMemberById(string memberId)
        {
            _membersById.TryGetValue(memberId, out var member);
            return member;
        }

        // Returns all registered members
        public IEnumerable<Member> GetAllMembers()
        {
            return _membersById.Values;
        }
    }
}
