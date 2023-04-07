using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    [SerializeField] TextAsset _pokemonFile;
    [SerializeField] TextAsset _itemFile;
    [SerializeField] TextAsset _movesFile;
    [SerializeField] TextAsset _typeFile;

    public DataReader Init()
    {
#if UNITY_EDITOR
        _pokemonFile ??= Resources.Load<TextAsset>("Pokemon");
        _itemFile   ??= Resources.Load<TextAsset>("Items");
        _movesFile  ??= Resources.Load<TextAsset>("Moves");
        _typeFile   ??= Resources.Load<TextAsset>("Types");
#endif
        return this;
    }

    public T ReadData<T>(TextAsset content) 
        => JsonUtility.FromJson<T>(content.text);   

    public IEnumerable<Pokemon> GetPokemons()
        => ReadData<PokemonData>(_pokemonFile).pokemons;
    
    // TODO
    public Pokemon GetPokemonById(int id)
        => GetPokemons().Where(p => p.id == id).Select(p => p).First();
    
    // TODO
    public IEnumerable<Pokemon> PokemonByType(string type)
        => GetPokemons().Where(p => p.type.Contains(type)).Select(p => p);

    // TODO
    public List<int> GetTopPokemonByBasePower(int count)
        => GetPokemons().OrderByDescending(p => p.statbase.BasePower).Select(p => p.id).Take(count).ToList();
    
    // TODO
    public List<int> GetDownPokemonByBasePower(int count)
        => GetPokemons().OrderBy(p => p.statbase.BasePower).Select(p => p.id).Take(count).ToList();

    // TODO
    public int GetPokemonPowerById(int id)
        => GetPokemons().Where(p => p.id == id).Select(p => p.statbase.BasePower).First();

    public IEnumerable<(int id, int power)> DecoratePokemonIdWithPower(IEnumerable<int> ids)
        => ids.Select(id => (id, GetPokemonPowerById(id)));
}
