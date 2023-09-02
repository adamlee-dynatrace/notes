using Note.Data.Models;

public interface INoteService
{
    Entry Create(Entry entry);
    bool Delete(int id);
    Entry Get(int id);
    List<Entry> GetAll();
    bool Update(int id, Entry updatedEntry);
}