//index.js
//获取应用实例
const app = getApp();
const articleListUrl = require('../../config').articleUrl;
var util = require('../../utils/util.js');
Page({
  data: {
    articles: [],//返回数据
    pageIndex: 1,//设置加载的第几次，默认是第一次  
    pageSize: 10,//每页大小
    searchKey: '',//搜索关键字
    isFromSearch: true,// 判断是不是查询
    searchLoading: false,//"上拉加载"的变量，默认false，隐藏  
    searchLoadingComplete: false,//“没有数据”的变量，默认false，隐藏  
    firstLoadPage: true
  },
  onLoad: function () {
    app.showLoading();
    this.loadData();
  },
  loadData: function () {
    var that = this;
    wx.request({
      url: articleListUrl,
      data: {
        pageIndex: that.data.pageIndex,
        pageSize: that.data.pageSize,
        name: that.data.searchKey
      },
      success: function (res) {
        if (res.data.Rows.length > 0) {
          for (let i = 0; i<res.data.Rows.length;i++)
          {
            res.data.Rows[i].PublishedDate=util.formatTime(new Date(res.data.Rows[i].PublishedDate));
          }
          let searchList = [];
          //如果isFromSearch是true从data中取出数据，否则先从原来的数据继续添加  
          that.data.isFromSearch ? searchList = res.data.Rows : searchList = that.data.articles.concat(res.data.Rows);
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
      }
    });
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
  jump: function (event) {
    wx.navigateTo({
      url: '/pages/articleDetails/index?id=' + event.currentTarget.dataset.id
    });
  },
  bindKeywordInput: function (e) {
    this.setData({
      searchKey: e.detail.value
    })
  },
  keywordSearch: function () {
    this.setData({
      pageIndex: 1,   //第一次加载，设置1  
      articles: [],  //放置返回数据的数组,设为空  
      isFromSearch: true,  //第一次加载，设置true  
      searchLoading: true,  //把"上拉加载"的变量设为true，显示  
      searchLoadingComplete: false //把“没有数据”设为false，隐藏  
    })
    this.loadData();
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
