using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    public enum UserUILookType
    {
        Default,
        Primary,
        Success,
        Info,
        Warning,
        Danger

    }
    public static class UIMessage
    {

        public static string Message2User(string message, UserUILookType type/*=UserUILookType.Default*/)
        {
            string icon = "info-sign";
            switch (type)
            {
                case UserUILookType.Info:
                    icon = "info-sign";
                    break;
                case UserUILookType.Danger:
                    icon = "exclamation-sign";
                    break;
                case UserUILookType.Success:
                    icon = "ok-sign";
                    break;
                case UserUILookType.Warning:
                    icon = "warning-sign";
                    break;
            }
            string className = type.ToString().ToLower();
            string msg = string.Format(@"<div id='msgdlg' class='alert alert-{2} fade in' style='margin:10px 0 !important' >
                                           <a class='glyphicon glyphicon-remove' data-dismiss='alert' onclick='$(this).parent().fadeOut(); return false;' style='float:right; cursor: pointer;text-decoration: none;' ></a>
                                            <div style='font-size: 20pt;float: left;margin-right: 10px;' class='glyphicon glyphicon-{3}' title='{0:hh:mm:ss tt}'></div><span style='font-weight:bold;font-size:12pt;'> {1}</span>
                                        </div>
{4}", DateTime.UtcNow.AddHours(6), message, className, icon, "<script type='text/javascript' > setTimeout(function(){  $('#msgdlg').fadeOut();},10000);</script>");
            return msg;
        }
        public static string Message2UserWait(string message, UserUILookType type)
        {
            string icon = "info-sign";
            switch (type)
            {
                case UserUILookType.Info:
                    icon = "info-sign";
                    break;
                case UserUILookType.Danger:
                    icon = "exclamation-sign";
                    break;
                case UserUILookType.Success:
                    icon = "ok-sign";
                    break;
                case UserUILookType.Warning:
                    icon = "warning-sign";
                    break;
            }
            string className = type.ToString().ToLower();
            string msg = string.Format(@"<div id='msgdlg' class='alert alert-{2} fade in' style='margin:10px 0 !important' >
                                           <a class='glyphicon glyphicon-remove' data-dismiss='alert' onclick='$(this).parent().fadeOut(); return false;' style='float:right; cursor: pointer;text-decoration: none;' ></a>
                                            <div style='font-size: 20pt;float: left;margin-right: 10px;' class='glyphicon glyphicon-{3}' title='{0:hh:mm:ss tt}'></div><span style='font-weight:bold;font-size:12pt;'> {1}</span>
                                        </div>", DateTime.UtcNow.AddHours(6), message, className, icon);
            return msg;
        }

    }
}
