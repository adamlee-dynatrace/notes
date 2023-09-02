using Note.Data.Models;
using System.Collections.Generic;
using System.Linq;

public class NoteService : INoteService
{
    private List<Entry> entries = new List<Entry>()
    {
        new Entry
        {
            Id = 1,
            Title = "First Entry",
            Content = "First Entry Content"
        },
        new Entry
        {
            Id = 2,
            Title = "Second Entry",
            Content = "Second Entry Content"
        }
    };

    // Create a new entry
    public Entry Create(Entry entry)
    {
        entry.Id = GetNextId();
        entries.Add(entry);
        return entry;
    }

    // Retrieve an entry by ID
    public Entry Get(int id)
    {
        return entries.FirstOrDefault(entry => entry.Id == id);
    }

    // Retrieve all entries
    public List<Entry> GetAll()
    {
        return entries.ToList(); // Return a copy to prevent external modification.
    }

    // Update an existing entry
    public bool Update(int id, Entry updatedEntry)
    {
        Entry existingEntry = Get(id);
        if (existingEntry != null)
        {
            existingEntry.Title = updatedEntry.Title;
            existingEntry.Content = updatedEntry.Content;
            return true;
        }
        return false;
    }

    // Delete an entry by ID
    public bool Delete(int id)
    {
        Entry entryToDelete = Get(id);
        if (entryToDelete != null)
        {
            entries.Remove(entryToDelete);
            return true;
        }
        return false;
    }

    // Get the next available ID
    private int GetNextId()
    {
        int maxId = entries.Count > 0 ? entries.Max(entry => entry.Id) : 0;
        return maxId + 1;
    }

}
