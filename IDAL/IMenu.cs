using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 菜单接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// 根据用户主键id查询用户可以访问的菜单
        /// </summary>
        DataTable GetUserMenu(int id);

        /// <summary>
        /// 根据角色id获取此角色可以访问的菜单和菜单下的按钮（编辑角色-菜单使用）
        /// </summary>
        DataTable GetAllMenu(int roleId);

        /// <summary>
        /// 根据用户主键id查询用户拥有的权限（后台首页“我的权限”）
        /// </summary>
        DataTable GetMyAuthority(int id);

        /// <summary>
        /// 获取菜单按钮
        /// </summary>
        DataTable GetMenuButton(int menuid);

        /// <summary>
        /// 分配菜单按钮
        /// </summary>
        bool SetMenuButton(string menuid,string buttonids);
    }
}
