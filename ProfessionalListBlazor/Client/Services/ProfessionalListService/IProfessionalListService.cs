
namespace ProfessionalListBlazor.Client.Services.ProfessionalListService
{
    public interface IProfessionalListService
    {
        List<ProfessionalList> Lists {get; set;}
        List<Style> Styles {get; set;}
        Task GetStyles();
        Task GetProfessionalLists();
        Task<ProfessionalList> GetSingleList(int id);
        Task CreateList(ProfessionalList list);
        Task UpdateList(ProfessionalList list);
        Task DeleteList(int id);
    }
}
