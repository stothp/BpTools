﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BpToolsWPFClientTest
{
    /// <summary>
    /// Interaction logic for StageEnd.xaml
    /// </summary>
    public partial class StageEnd : Stage
    {
        public StageEnd(BpTools.StageEnd stageEnd) : base(stageEnd)
        {
            InitializeComponent();
        }
    }
}