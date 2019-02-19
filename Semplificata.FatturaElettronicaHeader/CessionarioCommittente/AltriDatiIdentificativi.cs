﻿using System.Xml;
using FatturaElettronica.Common;
using Newtonsoft.Json;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Altri dati identificativi del cessionario / committente.
    /// </summary>
    /// <seealso cref="FatturaElettronica.Common.BaseClassSerializable" />
    public class AltriDatiIdentificativi : BaseClassSerializable
    {
        /// <summary>
        /// Altri dati fiscali del cessionario / committente.
        /// </summary>
        public AltriDatiIdentificativi()
        {
            Sede = new SedeCessionarioCommittente();
        }
        public AltriDatiIdentificativi(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        
        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [DataProperty(order: 0)]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [DataProperty(order: 1)]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [DataProperty(order: 2)]
        public string Cognome { get; set; }

        /// <summary>
        /// Dati della sede del cessionario / committente.
        /// </summary>
        [DataProperty]
        public SedeCessionarioCommittente Sede { get; set; }

        /// <summary>
        /// Blocco da valorizzare nei casi di cessionario/committente non residente e con stabile organizzazione in Italia.
        /// </summary>
        [DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { get; set; }

        /// <summary>
        /// Blocco da valorizzare nei casi in cui il cessionario/committente si avvalga di un rappresentante fiscale in Italia.
        /// </summary>
        [DataProperty]
        public RappresentanteFiscaleCessionarioCommittente RappresentanteFiscale { get; set; }

        /// <summary>
        /// Returns Cognome and Nome as a single value.
        /// </summary>
        /// <remarks>This is not a OrderedDataProperty so it will not be serialized to XML.</remarks>
        [JsonIgnore]
        public string CognomeNome
        {
            get
            {
                var r = ((Cognome ?? string.Empty) + " " + (Nome ?? string.Empty)).Trim();
                return string.IsNullOrEmpty(r) ? null : r;
            }
        }
    }
}
