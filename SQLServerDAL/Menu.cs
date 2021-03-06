﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 菜单（SQL Server数据库实现）
    /// </summary>
    public class Menu : ZGZY.IDAL.IMenu
    {
        /// <summary>
        /// 根据用户主键id查询用户可以访问的菜单
        /// </summary>
        public DataTable GetUserMenu(int id, int mainMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(m.Name) menuname,m.Id menuid,m.Icon icon,u.Id userid,u.UserId username,m.ParentId menuparentid,m.Sort menusort,m.LinkAddress linkaddress from tbUser u");
            strSql.Append(" join tbUserRole ur on u.Id=ur.UserId");
            strSql.Append(" join tbRoleMenuButton rmb on ur.RoleId=rmb.RoleId");
            strSql.Append(" join tbMenu m on rmb.MenuId=m.Id");
            strSql.Append(" where u.Id=@Id and (m.MainMenuId = @MainMenuId or ISNULL(m.MainMenuId,0) = 0) order by m.ParentId,m.Sort");

            SqlParameter[] paras = { 
                                   new SqlParameter("@Id", id),
                                   new SqlParameter("@MainMenuId", mainMenuId),
                                   };
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
        }

        /// <summary>
        /// 根据角色id获取此角色可以访问的菜单和菜单下的按钮（编辑角色-菜单使用）
        /// </summary>
        public DataTable GetAllMenu(int roleId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select m.Id menuid,m.Name menuname,m.ParentId parentid,m.Icon menuicon,mb.ButtonId buttonid,b.Name buttonname,b.Icon buttonicon,rmb.RoleId roleid,case when isnull(rmb.ButtonId , 0) = 0 then 'false' else 'true' end checked");
            sqlStr.Append(" from tbMenu m");
            sqlStr.Append(" left join tbMenuButton mb on m.Id=mb.MenuId");
            sqlStr.Append(" left join tbButton b on mb.ButtonId=b.Id");
            sqlStr.Append(" left join tbRoleMenuButton rmb on(mb.MenuId=rmb.MenuId and mb.ButtonId=rmb.ButtonId and rmb.RoleId = @RoleId)");
            sqlStr.Append(" order by m.ParentId,m.Sort,b.Sort");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlStr.ToString(), new SqlParameter("@RoleId", roleId));
        }

        /// <summary>
        /// 根据用户主键id查询用户拥有的权限（后台首页“我的权限”）
        /// </summary>
        public DataTable GetMyAuthority(int id)
        {
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, "sp_GetAuthorityByUserId", new SqlParameter("@userId", id));
        }

        /// <summary>
        /// 根据菜单id查询菜单分配的按钮
        /// </summary>
        public DataTable GetMenuButton(int menuid)
        {
            string sqlStr;
            sqlStr = "select buttonid from tbMenuButton where menuid = " + menuid.ToString();
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlStr);
        }

        /// <summary>
        /// 获取手风琴菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetMainMenu(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Icon from tbMainMenu order by Sort");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获取根节点菜单所属主菜单Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetBelongMainMenuId(int id)
        {
            string sqlStr = "select isnull(MainMenuId,0) as MainMenuId from tbMenu where Id = " + id.ToString();
            return (int)ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlStr, null);
        }

        public bool SetMenuButton(string menuid, string buttonids)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@inmenuid",menuid),
                                       new SqlParameter("@inbuttonids",buttonids)
                                       };
            int result = ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, "sp_SetMenuButton", paras);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetMainMenu(string menuId, string mainMenuId)
        {
            string sqlStr = string.Format("update tbMenu set MainMenuId = {0} where Id = {1}", mainMenuId, menuId);
            int result = ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlStr, null);
            return result > 0 ? true : false;
        }
    }
}
