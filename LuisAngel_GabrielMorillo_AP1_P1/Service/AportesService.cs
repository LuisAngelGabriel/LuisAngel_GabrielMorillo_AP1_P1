using LuisAngel_GabrielMorillo_AP1_P1.DAL;
using LuisAngel_GabrielMorillo_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LuisAngel_GabrielMorillo_AP1_P1.Service;

public class AportesService(IDbContextFactory<Contexto> DbFactory)
{

    public async Task <bool> Guardar(Aportes aporte)

    {
        if(!await Existe(aporte.AportesId))
        {

            return await Insertar(aporte);

        }
        else
        {
            return await Modificar(aporte);
        }

     }

    public async Task<bool> Existe(int AporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AnyAsync(a => a.AportesId == AporteId);
    }
    private async Task<bool> Insertar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<Aportes?> Buscar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.FirstOrDefaultAsync(a => a.AportesId == aporteId);
    }
    public async Task<bool> Eliminar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking().Where(a => a.AportesId == aporteId).ExecuteDeleteAsync() > 0;
    }
    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking().Where(criterio).ToListAsync();
    }
}


