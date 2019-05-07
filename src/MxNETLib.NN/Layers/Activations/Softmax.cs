﻿using MxNet.DotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers.Activations
{
    public class Softmax : BaseLayer, ILayer
    {
        public Softmax()
            : base("softmax")
        {

        }

        public Symbol Build(Symbol x)
        {
            return new Operator("SoftmaxActivation").SetInput("data", x)
                                            .CreateSymbol();
        }
    }
}