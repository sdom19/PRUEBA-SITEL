﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.SIMEF.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PredicadosSQLFormulasCalculo {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PredicadosSQLFormulasCalculo() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GB.SIMEF.Resources.PredicadosSQLFormulasCalculo", typeof(PredicadosSQLFormulasCalculo).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT SUM(PorcCumpl) FROM [CalidadIndicadorCalculo].[dbo].[FactRigurosidadFac] where IdIndicador = &apos;{0}&apos;.
        /// </summary>
        public static string calidad_PorcentajeCumplimiento {
            get {
                return ResourceManager.GetString("calidad_PorcentajeCumplimiento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT SUM(PorcentInd) FROM [CalidadIndicadorCalculo].[dbo].[FactRigurosidadFac] where IdIndicador = &apos;{0}&apos;.
        /// </summary>
        public static string calidad_PorcentajeIndicador {
            get {
                return ResourceManager.GetString("calidad_PorcentajeIndicador", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @UnidadMedida int = {0};
        ///
        ///declare @IdTipoFechaInicio int = {1};
        ///declare @FechaInicio datetime = &apos;{2}&apos;;
        ///declare @IdCategoriaInicio int = {3};
        ///
        ///declare @IdTipoFechaFinal int = {4};
        ///declare @FechaFinal datetime = &apos;{5}&apos;;
        ///declare @IdCategoriaFinal int = {6};
        ///
        ///declare @IndicadorReferencia int = $$$;
        ///
        ///declare @numeroFila int =1;
        ///declare @IdResultadoIndicador uniqueidentifier;
        ///
        ///select top 1 @IdResultadoIndicador= a.IdResultado 
        ///from IndicadorResultado a
        ///inner join IndicardorResultadoDetalle [rest of string was truncated]&quot;;.
        /// </summary>
        public static string fonatel_definicionFechas {
            get {
                return ResourceManager.GetString("fonatel_definicionFechas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @FechaUltimoRegistro date = null;
        ///declare @IndicadorSalida int = {0};
        ///declare @IdAcumulacion int = {1};
        ///declare @IdVariable int = {2};
        ///declare @IdCategoria int = {3};
        ///declare @IdCategoriaDetalle int = {4};
        ///declare @IndicadorReferencia int = $$$;
        ///
        ///SELECT top 1 @FechaUltimoRegistro = FechaCreacion from IndicadorResultado
        ///WHERE IdIndicador = @IndicadorSalida
        ///ORDER BY FechaCreacion DESC 
        ///
        ///
        ///IF @FechaUltimoRegistro is null and @IdAcumulacion &lt;&gt; 0
        ///BEGIN
        ///    SET @IdAcumulacion = 0;
        ///END; 
        ///
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string fonatel_variablesDatoCriterio {
            get {
                return ResourceManager.GetString("fonatel_variablesDatoCriterio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @pIdCriterio int = {0};
        ///	declare @pIdDetalle int = {1};
        ///
        ///WITH PrincipalQuery
        ///	AS
        ///	(	
        ///	SELECT 
        ///		DIM.Indicador.IdIndicador, 
        ///		DIM.Indicador.CodIndicador, 
        ///		DIM.Criterio.IdCriterio, 
        ///		DIM.Criterio.CodCriterio,
        ///		DIM.Criterio.DesCriterio, 
        ///		DIM.JerarquiaIndicadorUnico.DesJerarquiaIndicadorUnico,
        ///		FACT.JerarquiaIndicadorMercados.IdFechaIndicador, 
        ///		FACT.JerarquiaIndicadorMercados.Valor, 
        ///		FACT.JerarquiaIndicadorMercados.IdOperador, 
        ///		DIM.ParametroIndicador.FechaUltimaPublicacion, [rest of string was truncated]&quot;;.
        /// </summary>
        public static string mercados {
            get {
                return ResourceManager.GetString("mercados", resourceCulture);
            }
        }
    }
}
