using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace AutomapperBenchmark;

public class AutomapperVsExt
{
    private readonly UserModel _model;
    private readonly List<UserModel> _models;
    private readonly IMapper _mapper;

    public AutomapperVsExt()
    {
        var fixture = new Fixture();
        _model = fixture.Create<UserModel>();
        _models = new List<UserModel>(fixture.CreateMany<UserModel>(10000));
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AddressModel, Address>();
            cfg.CreateMap<UserModel, User>();
        }));
    }
    
    [Benchmark]
    public User Automapper() =>
        _mapper.Map<UserModel, User>(_model);

    [Benchmark]
    public User Ext() =>
        _model.ToUser();

    [Benchmark]
    public List<User> AutomapperList() =>
        _mapper.Map<List<UserModel>, List<User>>(_models);

    [Benchmark]
    public List<User> ExtList() =>
        _models.Select(x => x.ToUser()).ToList();
}