using System;
using UnityEngine;

[Serializable]
public struct Condicion 
{
    public enum EstadosMentales { VoluntadDeVivir, EnergiaMental, MascaraSocial};
    public enum Comparacion { MayorA, MenorA, Igual};

    public EstadosMentales enem;
    public Comparacion comparacion;
    public int valorAComparar;

    public bool comprar()
    {
        int stat = 0;

        switch(enem)
        {
            case EstadosMentales.VoluntadDeVivir:
                stat = Stats.VV;
                break;
            case EstadosMentales.EnergiaMental:
                stat = Stats.EM;
                break;
            case EstadosMentales.MascaraSocial:
                stat = Stats.MS;
                break;
        }

        switch (comparacion)
        {
            case Comparacion.MayorA:
                if (stat > valorAComparar)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Comparacion.MenorA:
                if (stat < valorAComparar)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case Comparacion.Igual:
                if (stat == valorAComparar)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        return false;
    }
}
