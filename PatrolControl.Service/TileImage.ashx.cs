﻿using System.Configuration;
using System.IO;
using System.Web;

namespace PatrolControl.Service
{
    /// <summary>
    /// Summary description for TileImage
    /// </summary>
    public class TileImage : IHttpHandler
    {

        private string _tilePath = Path.Combine(
            HttpContext.Current.Server.MapPath("~"),
            ConfigurationManager.AppSettings["TilePath"]);

        public void ProcessRequest(HttpContext context)
        {
            var x = context.Request.Params["x"];
            var y = context.Request.Params["y"];
            var z = context.Request.Params["z"];
            if (x == null || y == null || z == null || _tilePath == null)
            {
                context.Response.Write("X or Y or Z parameters or TilePath in web.config is not set");
                return;
            }
            var tilePath = string.Format(_tilePath, x, y, z);
            if (!File.Exists(tilePath))
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Tile not found");
                return;
            }
            context.Response.ContentType = "image/png";
            context.Response.WriteFile(tilePath);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}