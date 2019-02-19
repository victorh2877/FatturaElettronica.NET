﻿using System.Collections.Generic;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;

namespace FatturaElettronica
{
    public class FatturaSemplificata : BaseClassSerializable
    {
        public FatturaSemplificata()
        {
            FatturaElettronicaHeader = new Semplificata.FatturaElettronicaHeader.FatturaElettronicaHeader();
            FatturaElettronicaBody = new List<Semplificata.FatturaElettronicaBody.FatturaElettronicaBody>();
        }

        public override void WriteXml(System.Xml.XmlWriter w)
        {
            w.WriteStartElement(RootElement.Prefix, RootElement.LocalName, RootElement.NameSpace);
            w.WriteAttributeString("versione", FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            foreach (var a in RootElement.ExtraAttributes)
            {
                w.WriteAttributeString(a.Prefix, a.LocalName, a.ns, a.value);
            }
            base.WriteXml(w);
            w.WriteEndElement();
        }

        public override void ReadXml(System.Xml.XmlReader r)
        {
            r.MoveToContent();
            base.ReadXml(r);
        }

        public static FatturaSemplificata CreateInstance()
        {
            var f = new FatturaSemplificata();

            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.Semplificata;

            return f;
        }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Intestazione della comunicazione.
        /// </summary>
        [DataProperty]
        public Semplificata.FatturaElettronicaHeader.FatturaElettronicaHeader FatturaElettronicaHeader { get; set; }

        /// <summary>
        /// Lotto di fatture incluse nella comunicazione.
        /// </summary>
        /// <remarks>Il blocco ha molteciplità 1 nel caso di fattura singola; nel caso di lotto di fatture, si ripete
        /// per ogni fattura componente il lotto stesso.</remarks>
        [DataProperty]
        public List<Semplificata.FatturaElettronicaBody.FatturaElettronicaBody> FatturaElettronicaBody { get; set; }

    }
}
