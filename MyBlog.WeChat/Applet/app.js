//app.js
App({
  onLaunch: function () {
  
  },
  globalData: {
  },
  showLoading: function () {
    wx.showLoading({
      title: '加载中'
    });
  },
  cancelLoading: function () {
    wx.hideLoading();
  }
})