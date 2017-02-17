using System;

namespace MyServiceLibrary
{
    public interface IUserInterface
    {
        bool Add(User user);
        bool Delete(User user);
        User SearchUserBySomeName(Predicate<string> namePredicate);
    }
}