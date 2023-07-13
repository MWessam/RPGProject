using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class StaticIntermediateDataContainer<T>          // Acting as an rax register
{
    private static T intermediateData;

    public static T IntermediateData { 
        get => intermediateData; 
        set => intermediateData = value; 
    }
}

