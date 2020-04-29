﻿/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Image;
using MxNet.Recordio;
using System;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageRecordDataset : RecordFileDataset
    {
        internal int _flag;

        internal Func<NDArray, NDArray, (NDArray, NDArray)> _transform;

        public ImageRecordDataset(string filename, int flag = 1, Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) :
            base(filename)
        {
            this._flag = flag;
            this._transform = transform;
        }

        public new (NDArray, NDArray) this[int idx]
        {
            get
            {
                var record = base[idx];
                var (header, img) = RecordIO.UnPack(record);
                if (this._transform != null)
                {
                    return this._transform(Img.ImDecode(img, this._flag), header.Label);
                }

                return (Img.ImDecode(img, this._flag), header.Label);
            }
        }
    }
}