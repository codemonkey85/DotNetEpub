﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Epub
{
    class NCX
    {
        private string _title;
        private string _uid;
        private List<NavPoint> _navpoints;

        public NCX()
        {
            _navpoints = new List<NavPoint>();
        }

        public NCX(string title, string uid)
        {
            _title = title;
            _uid = uid;
            _navpoints = new List<NavPoint>();
        }

        public string ToXml()
        {
            XDocument topDoc = new XDocument();
            XElement navMap = new XElement("navMap");
            foreach (NavPoint n in _navpoints) 
            {
                navMap.Add(n.ToElement());
            }
            topDoc.Add(navMap);
            return topDoc.ToString();
        }

        public NavPoint AddNavPoint(string label, string id, string content, int playOrder)
        {
            NavPoint n = new NavPoint(label, id, content, playOrder);
            _navpoints.Add(n);

            return n;
        }
    }
}