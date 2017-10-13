// pages/category/index.js
const app = getApp();
const categoryUrl = require('../../config').categoryUrl;
Page({

  /**
   * 页面的初始数据
   */
  data: {
    category: []
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    app.showLoading();
    this.loadData();
  },
  loadData: function () {
    var that = this;
    wx.request({
      url: categoryUrl,
      success: function (res) {
        that.setData({
          category: res.data
        });
        app.cancelLoading();
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

  }
})