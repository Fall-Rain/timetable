namespace Model
{
    /// <summary>
    /// 字段详情
    /// </summary>
    public struct FeildDetail
    {
        /// <summary>
        /// xpath
        /// </summary>
        public string Xpath { get; set; }
        /// <summary>
        /// 内容类型
        /// </summary>
        public ContentType ContentType { get; set; }
        /// <summary>
        /// 属性值需要传入属性值key
        /// </summary>
        public string AttributeKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
