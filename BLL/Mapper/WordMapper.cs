using BLL.DTO;
using BLL.Forms;
using DAL.Models;

namespace BLL.Mapper;

public static class WordMapper
{
    public static WordEntity ToEntity(this AddWordForm form)
    {
        return new WordEntity()
        {
            Id = 0,
            Word = form.Word,
            Date = DateTime.Now
        };
    }

    public static WordDTO ToDTO(this WordEntity entity)
    {
        return new WordDTO()
        {
            Id = entity.Id,
            Word = entity.Word
        };
    }
}