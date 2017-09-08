using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAuthenticationExample.Models {

  public class IntervalModel {
    
    public int IntervalID { get; set; }

    public int SegmentID { get; set; }

    public int Sequence { get; set; }

    public int Duration { get; set; }

    public int RPMFrom { get; set; }

    public int RPMTo { get; set; }

    public int PulseZoneFrom { get; set; }

    public int PulseZoneTo { get; set; }

    public int Intensity { get; set; }

    public int PositionTypeID { get; set; }

    public string PositionTypeName { get; set; }

    public int CycleID { get; set; }

    public string CycleName { get; set; }

    public int FTPFrom { get; set; }

    public int FTPTo { get; set; }

    public int MAPFrom { get; set; }

    public int MAPTo { get; set; }

    public int FTHRFrom { get; set; }

    public int FTHRTo { get; set; }

    public int LTHRFrom { get; set; }

    public int LTHRTo { get; set; }

    public int VO2From { get; set; }

    public int VO2To { get; set; }

    public int ScaleCoggan { get; set; }

    public int Scale1to5 { get; set; }

    public int ScaleBorg { get; set; }

    public int CreatedFromCode { get; set; }
  }
}