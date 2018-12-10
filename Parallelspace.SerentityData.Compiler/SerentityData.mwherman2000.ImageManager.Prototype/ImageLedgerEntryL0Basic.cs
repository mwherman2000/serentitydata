using Parallelspace.SerentityData.Ledgers;
using System;

/// <summary>
/// SerentityData.mwherman2000.ImageManager.Prototype - Level 0 Basic
///
/// Processed:       2018-03-19 11:02:51 PM by SerentityData Compiler (SDC) 3.0 v1.0.0.0
/// SDC Project:     https://github.com/mwherman2000/serentitydata/blob/master/README.md
/// SDC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace SerentityData.mwherman2000.ImageManager.Prototype
{
    public partial struct ImageLedgerEntry : IGenericLedgerEntry030Basic<ImageLedgerEntry> /* Level 0 Basic */
    {
        private Int32  _imageVersion;
        private string _imageName;
        private byte[] _imageContent;
    }
}
