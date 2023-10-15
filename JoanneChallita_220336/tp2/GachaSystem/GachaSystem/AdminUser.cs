using GachaSystem;



public class AdminUser : BaseUser
{
    public AdminUser(int id, string firstName, string lastName, DateTime dateOfBirth)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        UserStatus = Status.Active;
    }



    public void UpdatePermanentBanner(List<GachaItem> newItems)
    {

    }



    public void AddExclusiveBanner(ExclusiveBanner banner)
    {

    }



    public void UpdateExclusiveBanner(int bannerId, ExclusiveBanner updatedBanner)
    {

    }



    public void DeleteExclusiveBanner(int bannerId)
    {

    }



    public void AddUser(BaseUser user)
    {

    }



    public void RemoveUser(int userId)
    {

    }



    public void UpdateSystemVersion(GachaSystem.Version newVersion)
    {
        
    }



    public override void Validate()
    {

    }
}
