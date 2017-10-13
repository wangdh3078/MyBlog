// pages/categoryArticles/index.js
const app = getApp();
const articleListUrl = require('../../config').articleUrl;
var util = require('../../utils/util.js');
Page({

  /**
   * 页面的初始数据
   */
  data: {
    articles: [],//返回数据
    pageIndex: 1,//设置加载的第几次，默认是第一次  
    pageSize: 10,//每页大小
    categoryId: 0,//搜索关键字
    searchLoading: false,//"上拉加载"的变量，默认false，隐藏  
    searchLoadingComplete: false,//“没有数据”的变量，默认false，隐藏  
    firstLoadPage: true
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.setData({
      categoryId: options.id
    });
    wx.setNavigationBarTitle({
      title: options.name
    });
    app.showLoading();
    this.loadData();
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },loadData: function () {
    var that = this;
    wx.request({
      url: articleListUrl,
      data: {
        pageIndex: that.data.pageIndex,
        pageSize: that.data.pageSize,
        categoryId: that.data.categoryId
      },
      success: function (res) {
        if (res.data.Rows.length > 0) {
          for (let i = 0; i < res.data.Rows.length; i++) {
            res.data.Rows[i].PublishedDate = util.formatTime(new Date(res.data.Rows[i].PublishedDate));
          }
          let searchList = [];
          searchList = that.data.articles.concat(res.data.Rows);
          that.setData({
            articles: searchList, //获取数据数组  
            searchLoading: false   //把"上拉加载"的变量设为false，显示  
          });
        } else {
          that.setData({
            searchLoadingComplete: true, //把“没有数据”设为true，显示  
            searchLoading: false  //把"上拉加载"的变量设为false，隐藏  
          });
        }
        if (that.data.firstLoadPage) {
          app.cancelLoading();
          that.setData({
            firstLoadPage: false
          });
        }
      },
      fail: function (data) {
        console.log('请求失败：');
        console.log(data)
      },
      complete: function (data) {
        console.log('请求完成');
      }
    });
  },
  jump: function (event) {
    wx.navigateTo({
      url: '/pages/articleDetails/index?id=' + event.currentTarget.dataset.id
    });
  },
  searchScrollLower: function () {
    let that = this;
    if (!that.data.searchLoadingComplete) {
      that.setData({
        searchLoading: true
      });
      that.setData({
        pageIndex: that.data.pageIndex + 1,  //pageIndex+1  
        isFromSearch: false  //触发到上拉事件，把isFromSearch设为为false  
      });
      that.loadData();
    }
  }
})