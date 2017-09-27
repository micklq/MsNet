/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50718
Source Host           : 127.0.0.1:3306
Source Database       : hzdb

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2017-09-23 16:20:43
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for articles
-- ----------------------------
DROP TABLE IF EXISTS `articles`;
CREATE TABLE `articles` (
  `ArticleId` bigint(20) NOT NULL AUTO_INCREMENT,
  `CategoryId` bigint(20) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Editor` varchar(255) DEFAULT NULL,
  `Media` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Contents` varchar(255) DEFAULT NULL,
  `BrowseTimes` int(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ArticleId`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of articles
-- ----------------------------
INSERT INTO `articles` VALUES ('1', '2', '资讯标题0', '资讯作者0', '资讯来源0', '资讯简介0', '<p>资讯内容0</p>', '2', '2017-09-22 15:49:21', '2017-09-23 15:34:25');
INSERT INTO `articles` VALUES ('2', '1', '资讯标题1', '资讯作者1', '资讯来源1', '资讯简介1', '资讯内容1', '0', '2017-09-22 15:49:22', '2017-09-22 15:49:22');
INSERT INTO `articles` VALUES ('3', '2', '资讯标题2', '资讯作者2', '资讯来源2', '资讯简介2', '<p>资讯内容2</p>', '0', '2017-09-22 15:49:22', '2017-09-23 15:34:12');
INSERT INTO `articles` VALUES ('4', '1', '资讯标题3', '资讯作者3', '资讯来源3', '资讯简介3', '资讯内容3', '0', '2017-09-22 15:49:22', '2017-09-22 15:49:22');
INSERT INTO `articles` VALUES ('5', '2', '资讯标题4', '资讯作者4', '资讯来源4', '资讯简介4', '<p>资讯内容4</p>', '0', '2017-09-22 15:49:22', '2017-09-23 13:21:47');

-- ----------------------------
-- Table structure for articlescategory
-- ----------------------------
DROP TABLE IF EXISTS `articlescategory`;
CREATE TABLE `articlescategory` (
  `CategoryId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `ParentId` bigint(20) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of articlescategory
-- ----------------------------
INSERT INTO `articlescategory` VALUES ('1', '最新动态', '最新动态', '0', '0', '2017-09-22 15:38:26', '2017-09-23 13:20:57');
INSERT INTO `articlescategory` VALUES ('2', '行业资讯', '行业资讯', '0', '0', '2017-09-23 13:18:09', '2017-09-23 13:21:34');

-- ----------------------------
-- Table structure for permissionmenu
-- ----------------------------
DROP TABLE IF EXISTS `permissionmenu`;
CREATE TABLE `permissionmenu` (
  `PermissionId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `ParentId` bigint(20) NOT NULL,
  `Sort` int(11) NOT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`PermissionId`)
) ENGINE=MyISAM AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of permissionmenu
-- ----------------------------
INSERT INTO `permissionmenu` VALUES ('1', '资讯管理', null, '0', '1', '', '2017-08-10 18:10:07', '2017-08-10 18:10:07');
INSERT INTO `permissionmenu` VALUES ('2', '图片管理', null, '0', '2', '', '2017-08-10 18:11:25', '2017-08-10 18:11:25');
INSERT INTO `permissionmenu` VALUES ('3', '产品管理', null, '0', '3', '', '2017-08-10 18:11:47', '2017-08-10 18:11:47');
INSERT INTO `permissionmenu` VALUES ('4', '资讯管理', null, '1', '1', 'articles/list  ', '2017-08-10 18:14:31', '2017-09-21 10:10:25');
INSERT INTO `permissionmenu` VALUES ('5', '评论管理', null, '0', '3', ' ', '2017-08-10 18:16:02', '2017-08-10 18:16:02');
INSERT INTO `permissionmenu` VALUES ('6', '会员管理', null, '0', '5', ' ', '2017-08-10 18:18:24', '2017-08-10 18:18:24');
INSERT INTO `permissionmenu` VALUES ('7', '系统统计', null, '0', '7', '  ', '2017-08-10 18:18:40', '2017-08-10 18:26:54');
INSERT INTO `permissionmenu` VALUES ('8', '系统管理', null, '0', '8', null, '2017-08-10 18:19:34', '2017-08-10 18:27:11');
INSERT INTO `permissionmenu` VALUES ('12', '图片管理', null, '2', '1', 'pictures/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('13', '品牌管理', null, '3', '1', 'products/brand', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('14', '分类管理', null, '3', '2', 'products/category', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('15', '产品管理', null, '3', '3', 'products/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('16', '评论列表', null, '5', '1', 'comment/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('17', '意见反馈', null, '5', '2', 'feedback/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('18', '会员列表', null, '6', '1', 'members/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('19', '删除的会员', null, '6', '2', 'members/del', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('20', '等级管理', null, '6', '3', 'members/level', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('21', '积分管理', null, '6', '4', 'members/scoreoperation', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('22', '浏览记录', null, '6', '5', 'members/recordbrowse', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('23', '下载记录', null, '6', '6', 'members/recorddownload', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('24', '分享记录', null, '6', '7', 'members/recordshare ', '1911-10-10 00:00:00', '2017-08-11 09:52:20');
INSERT INTO `permissionmenu` VALUES ('25', '管理员管理', null, '0', '6', null, '1911-10-10 00:00:00', '2017-08-11 09:53:28');
INSERT INTO `permissionmenu` VALUES ('26', '角色管理', null, '25', '2', 'admin/roles ', '1911-10-10 00:00:00', '2017-08-11 09:55:54');
INSERT INTO `permissionmenu` VALUES ('27', '权限管理', null, '25', '1', 'admin/permissions ', '1911-10-10 00:00:00', '2017-08-11 09:56:09');
INSERT INTO `permissionmenu` VALUES ('28', '管理员列表', null, '25', '3', 'admin/list', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('29', '折线图', null, '7', '1', 'charts/charts1', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('30', '时间轴折线图', null, '7', '2', 'charts/charts2', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('31', '区域图', null, '7', '3', 'charts/charts3', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('32', '柱状图', null, '7', '4', 'charts/charts4', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('33', '饼状图', null, '7', '5', 'charts/charts5', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('34', '3D柱状图', null, '7', '6', 'charts/charts6', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('35', '3D饼状图', null, '7', '7', 'charts/charts7', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('36', '系统设置', null, '8', '1', 'system/base', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('37', '栏目管理', null, '8', '2', 'system/category', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('38', '数据字典', null, '8', '3', 'system/data', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('39', '屏蔽词', null, '8', '4', 'system/shielding', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('40', '系统日志', null, '8', '5', 'system/logs', '1911-10-10 00:00:00', '1911-10-10 00:00:00');
INSERT INTO `permissionmenu` VALUES ('42', '栏目管理', null, '1', '2', 'articles/categorys', '2017-09-23 12:08:14', '2017-09-23 12:08:14');

-- ----------------------------
-- Table structure for signedupinfo
-- ----------------------------
DROP TABLE IF EXISTS `signedupinfo`;
CREATE TABLE `signedupinfo` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `PassportId` bigint(20) DEFAULT NULL,
  `SignedUpTime` datetime DEFAULT NULL,
  `SignedUpIP` varchar(255) DEFAULT NULL,
  `HttpUserAgent` varchar(255) DEFAULT NULL,
  `HttpReferer` varchar(255) DEFAULT NULL,
  `RefererDomain` varchar(255) DEFAULT NULL,
  `UtmSource` varchar(255) DEFAULT NULL,
  `InviteCode` varchar(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of signedupinfo
-- ----------------------------
INSERT INTO `signedupinfo` VALUES ('1', '2', '2017-09-20 10:59:09', '127.0.0.1', 'nunit.framework.test', null, null, null, null, '2017-09-20 10:59:09', '2017-09-20 10:59:09');
INSERT INTO `signedupinfo` VALUES ('2', '3', '2017-09-20 11:02:22', '127.0.0.1', 'nunit.framework.test', null, null, null, null, '2017-09-20 11:02:30', '2017-09-20 11:02:30');
INSERT INTO `signedupinfo` VALUES ('3', '4', '2017-09-20 11:15:19', '127.0.0.1', 'nunit.framework.test', null, null, null, null, '2017-09-20 11:15:19', '2017-09-20 11:15:19');
INSERT INTO `signedupinfo` VALUES ('4', '5', '2017-09-20 12:45:25', '127.0.0.1', 'nunit.framework.test', null, null, null, null, '2017-09-20 12:45:25', '2017-09-20 12:45:25');
INSERT INTO `signedupinfo` VALUES ('5', '6', '2017-09-20 12:45:37', '127.0.0.1', 'nunit.framework.test', null, null, null, null, '2017-09-20 12:45:37', '2017-09-20 12:45:37');
INSERT INTO `signedupinfo` VALUES ('6', '7', '2017-09-20 18:18:22', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/admin/adminview', '192.168.1.21:8888', null, null, '2017-09-20 18:18:24', '2017-09-20 18:18:24');
INSERT INTO `signedupinfo` VALUES ('7', '8', '2017-09-21 10:19:38', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/admin/adminview', '192.168.1.21:8888', null, null, '2017-09-21 10:19:38', '2017-09-21 10:19:38');

-- ----------------------------
-- Table structure for userpassport
-- ----------------------------
DROP TABLE IF EXISTS `userpassport`;
CREATE TABLE `userpassport` (
  `PassportId` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Mobile` varchar(255) DEFAULT NULL,
  `RoleId` bigint(20) DEFAULT NULL,
  `RoleType` int(11) DEFAULT NULL,
  `PassportStatus` int(11) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`PassportId`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userpassport
-- ----------------------------
INSERT INTO `userpassport` VALUES ('3', '13683205266', null, '13683205266', '0', '0', '0', '2017-09-20 11:02:22', '2017-09-20 11:02:22');
INSERT INTO `userpassport` VALUES ('4', 'admin', null, '13683205265', '1', '1', '0', '2017-09-20 11:15:19', '2017-09-23 15:53:37');
INSERT INTO `userpassport` VALUES ('5', 'admin1', '12345@qq.com   ', '13683205267    ', '3', '1', '0', '2017-09-20 12:45:25', '2017-09-20 18:16:40');
INSERT INTO `userpassport` VALUES ('6', 'admin2', null, '13683205268  ', '4', '1', '0', '2017-09-20 12:45:37', '2017-09-21 10:38:14');
INSERT INTO `userpassport` VALUES ('7', 'admin11', '574078710@qq.com', '15112232345', '1', '1', '0', '2017-09-20 18:18:22', '2017-09-20 18:18:22');
INSERT INTO `userpassport` VALUES ('8', 'admin12', '574078710@qq.com         ', '15112232345         ', '3', '1', '999', '2017-09-21 10:19:38', '2017-09-23 11:34:32');

-- ----------------------------
-- Table structure for userprofile
-- ----------------------------
DROP TABLE IF EXISTS `userprofile`;
CREATE TABLE `userprofile` (
  `PassportId` bigint(20) NOT NULL,
  `NickName` varchar(255) DEFAULT NULL,
  `RealName` varchar(255) DEFAULT NULL,
  `Gender` varchar(11) DEFAULT NULL,
  `Mobile` varchar(255) DEFAULT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`PassportId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userprofile
-- ----------------------------
INSERT INTO `userprofile` VALUES ('3', '13683205266', null, null, '13683205266', null, '2017-09-20 11:02:22', '2017-09-20 11:02:22');
INSERT INTO `userprofile` VALUES ('4', 'admin', null, null, '13683205265', null, '2017-09-20 11:15:19', '2017-09-20 11:15:19');
INSERT INTO `userprofile` VALUES ('5', 'admin1', null, null, '13683205267    ', null, '2017-09-20 12:45:25', '2017-09-20 18:16:40');
INSERT INTO `userprofile` VALUES ('6', 'admin2', null, null, '13683205268  ', null, '2017-09-20 12:45:37', '2017-09-21 10:38:14');
INSERT INTO `userprofile` VALUES ('7', 'admin11', null, null, '15112232345', null, '2017-09-20 18:18:24', '2017-09-20 18:18:24');
INSERT INTO `userprofile` VALUES ('8', 'admin12', null, null, '15112232345         ', null, '2017-09-21 10:19:38', '2017-09-23 11:34:32');

-- ----------------------------
-- Table structure for userrole
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole` (
  `RoleId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userrole
-- ----------------------------
INSERT INTO `userrole` VALUES ('1', '系统管理员', '系统管理员', '1911-10-10 00:00:00', '2017-09-23 12:08:31');
INSERT INTO `userrole` VALUES ('2', '栏目编辑', '栏目编辑', '1911-10-10 00:00:00', '2017-09-21 16:44:15');
INSERT INTO `userrole` VALUES ('3', '运营人员', '运营人员', '1911-10-10 00:00:00', '2017-09-21 16:44:31');
INSERT INTO `userrole` VALUES ('4', '资讯管理', '资讯管理', '1911-10-10 00:00:00', '2017-09-21 10:38:25');

-- ----------------------------
-- Table structure for userrolepermission
-- ----------------------------
DROP TABLE IF EXISTS `userrolepermission`;
CREATE TABLE `userrolepermission` (
  `RoleId` bigint(20) NOT NULL,
  `PermissionId` bigint(20) NOT NULL,
  `ParentPermissionId` bigint(20) NOT NULL,
  `PermissionValue` int(20) NOT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userrolepermission
-- ----------------------------
INSERT INTO `userrolepermission` VALUES ('1', '40', '8', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '40', '8', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '40', '8', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '40', '8', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '40', '8', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '39', '8', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '39', '8', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '39', '8', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '39', '8', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '39', '8', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '38', '8', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '38', '8', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '38', '8', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '38', '8', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '38', '8', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '37', '8', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '37', '8', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '37', '8', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '37', '8', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '37', '8', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '36', '8', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '36', '8', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '36', '8', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '36', '8', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '36', '8', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '28', '25', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '28', '25', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '28', '25', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '28', '25', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '28', '25', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '26', '25', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '26', '25', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '26', '25', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '26', '25', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '26', '25', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '27', '25', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '27', '25', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '27', '25', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '27', '25', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '27', '25', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '42', '1', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '42', '1', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '42', '1', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '42', '1', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '42', '1', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '4', '1', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '4', '1', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '4', '1', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '4', '1', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('1', '4', '1', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('2', '4', '1', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('2', '4', '1', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('2', '4', '1', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('2', '4', '1', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('2', '4', '1', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '34', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '34', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '34', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '34', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '34', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '33', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '33', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '33', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '33', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '33', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '32', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '32', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '32', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '32', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '32', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '31', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '31', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '31', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '31', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '31', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '30', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '30', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '30', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '30', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '30', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '29', '7', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '29', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '29', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '29', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '29', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '24', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '24', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '24', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '24', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '24', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '23', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '23', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '23', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '23', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '23', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '22', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '22', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '22', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '22', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '22', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '21', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '21', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '21', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '21', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '21', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '20', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '20', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '20', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '20', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '20', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '19', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '19', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '19', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '19', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '19', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '18', '6', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '18', '6', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '18', '6', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '18', '6', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '18', '6', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '17', '5', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '17', '5', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '17', '5', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '17', '5', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '17', '5', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '16', '5', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '16', '5', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '16', '5', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '16', '5', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '16', '5', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '15', '3', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '15', '3', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '15', '3', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '15', '3', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '15', '3', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '14', '3', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '14', '3', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '14', '3', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '14', '3', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '14', '3', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '13', '3', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '13', '3', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '13', '3', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '13', '3', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '13', '3', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '4', '1', '5', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '4', '1', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '4', '1', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '4', '1', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '4', '1', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('4', '4', '1', '5', '2017-09-21 15:17:36', '2017-09-21 15:17:36');
INSERT INTO `userrolepermission` VALUES ('4', '4', '1', '4', '2017-09-21 15:17:36', '2017-09-21 15:17:36');
INSERT INTO `userrolepermission` VALUES ('4', '4', '1', '3', '2017-09-21 15:17:36', '2017-09-21 15:17:36');
INSERT INTO `userrolepermission` VALUES ('4', '4', '1', '2', '2017-09-21 15:17:36', '2017-09-21 15:17:36');
INSERT INTO `userrolepermission` VALUES ('4', '4', '1', '1', '2017-09-21 15:17:36', '2017-09-21 15:17:36');
INSERT INTO `userrolepermission` VALUES ('3', '35', '7', '1', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '35', '7', '2', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '35', '7', '3', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '35', '7', '4', null, null);
INSERT INTO `userrolepermission` VALUES ('3', '35', '7', '5', null, null);

-- ----------------------------
-- Table structure for usersecurity
-- ----------------------------
DROP TABLE IF EXISTS `usersecurity`;
CREATE TABLE `usersecurity` (
  `PassportId` bigint(20) NOT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `HashAlgorithm` varchar(255) DEFAULT NULL,
  `PasswordSalt` varchar(255) DEFAULT NULL,
  `LastPasswordChangedTime` datetime DEFAULT NULL,
  `IsLocked` int(255) DEFAULT NULL,
  `LastLockedTime` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(11) DEFAULT NULL,
  PRIMARY KEY (`PassportId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of usersecurity
-- ----------------------------
INSERT INTO `usersecurity` VALUES ('3', '$2a$09$nW8wDmURXaDEU4skgQOoZeHOketVbua9FBDoNaLZ/eD4U7pg9Ps/i', 'BCrypt9', 'SnNtiaGctkBRoCnZOCJU', '2017-09-20 11:02:05', '0', '2000-01-01 00:00:00', '0');
INSERT INTO `usersecurity` VALUES ('4', '$2a$10$q/XJSDXCn0f1qEvyFTtHB.x4FugpiQqu8R5sF6KnRgoY39PxBPWRS', 'BCrypt10', 'zUtdBUTxOVAlm1scG3czmg==', '2017-09-21 16:06:25', '0', '2017-09-23 15:53:26', '0');
INSERT INTO `usersecurity` VALUES ('5', '$2a$08$zHKLlVRfeS2cLo2CEiwLo.G9Ww9WR7EccE6fqy8jG2sajccxOaRhS', 'BCrypt8', 'sKMcSIxzWou81psTKwY=', '2017-09-20 12:45:25', '0', '2000-01-01 00:00:00', '0');
INSERT INTO `usersecurity` VALUES ('6', '$2a$11$rE3Q3ItBGNikrCIZ0d9BluaLDjyDzDVYkOyHOUgnC.hj3X.VRh/aS', 'BCrypt11', '6Xr9/mq5HVrH8fsxUIxNRPs=', '2017-09-21 10:33:02', '0', '2000-01-01 00:00:00', '2');
INSERT INTO `usersecurity` VALUES ('7', '$2a$07$xzsdA89BDhcP3zViWm8G2O4FFLkManUmxYD2DGLe5oVZ8TENUn2hO', 'BCrypt7', 'vaGN1o7syGfH3EV3WQ==', '2017-09-20 18:18:21', '0', '2000-01-01 00:00:00', '0');
INSERT INTO `usersecurity` VALUES ('8', '$2a$06$gmD73qF2KFysH12FoEE0aukTZ9TUR.BFpI18YcK955GLlTiyvCsee', 'BCrypt6', 'Qc9R9v0ov2NF1Psr', '2017-09-21 10:19:38', '0', '2017-09-23 11:34:15', '0');

-- ----------------------------
-- Table structure for webapplogs
-- ----------------------------
DROP TABLE IF EXISTS `webapplogs`;
CREATE TABLE `webapplogs` (
  `LogsId` bigint(20) NOT NULL AUTO_INCREMENT,
  `PassportId` bigint(20) DEFAULT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `UserAction` varchar(255) DEFAULT NULL,
  `Messages` varchar(255) DEFAULT NULL,
  `ClientIp` varchar(255) DEFAULT NULL,
  `HttpUserAgent` varchar(255) DEFAULT NULL,
  `HttpReferer` varchar(255) DEFAULT NULL,
  `RefererDomain` varchar(255) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `LastModifiedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`LogsId`)
) ENGINE=MyISAM AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of webapplogs
-- ----------------------------
INSERT INTO `webapplogs` VALUES ('63', '4', 'admin', '删除日志', '删除日志', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/system/logs', '192.168.1.21:8888', '2017-09-23 15:33:52', '2017-09-23 15:33:52');
INSERT INTO `webapplogs` VALUES ('64', '4', 'admin', '修改资讯', '资讯标题2', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/articles/articleview?id=3', '192.168.1.21:8888', '2017-09-23 15:34:12', '2017-09-23 15:34:12');
INSERT INTO `webapplogs` VALUES ('65', '4', 'admin', '修改资讯', '资讯标题0', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/articles/articleview?id=1', '192.168.1.21:8888', '2017-09-23 15:34:25', '2017-09-23 15:34:25');
INSERT INTO `webapplogs` VALUES ('66', '4', 'admin', '用户登录', '5次密码输入错误,账号已锁定', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/Auth/Login', '192.168.1.21:8888', '2017-09-23 15:53:26', '2017-09-23 15:53:26');
INSERT INTO `webapplogs` VALUES ('67', '4', 'admin', '用户登录', '登录成功', '192.168.1.21', 'Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:55.0) Gecko/20100101 Firefox/55.0', 'http://192.168.1.21:8888/Auth/Login', '192.168.1.21:8888', '2017-09-23 15:53:37', '2017-09-23 15:53:37');
