using BLL.DTO;
using BLL.Forms;
using BLL.Mapper;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services;

public class WordService
{
    private readonly WordRepository _wordRepository;

    public WordService(WordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }


    public bool Add(AddWordForm form)
    {
        return _wordRepository.Add(form.ToEntity());
    }

    public List<WordDTO> GetAll()
    {
        return _wordRepository.GetAll().Select(x => x.ToDTO()).ToList();
    }

    public bool Delete(int id)
    {
        WordEntity? entity = _wordRepository.GetById(id);

        if (entity is not null)
        {
            return _wordRepository.Delete(entity);
        }

        return false;
    }

    public WordDTO? GetById(int id)
    {
        WordEntity? entity = _wordRepository.GetById(id);

        if (entity is not null)
        {
            return entity.ToDTO();
        }

        return null;
    }

    public WordDTO GetRandom()
    {
        return _wordRepository.GetRandom().ToDTO();
    }
}