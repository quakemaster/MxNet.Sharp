﻿using MxNet.NN.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers.Activations
{
    public class HardSigmoid : BaseLayer, ILayer
    {
        public HardSigmoid()
            : base("hardsigmoid")
        {

        }

        public Symbol Build(Symbol x)
        {
            return new Operator("HardSigmoid").SetInput("data", x)
                                            .CreateSymbol(ID);
        }
    }
}
