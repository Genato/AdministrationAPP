namespace AdministrationApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Security;

    /// <summary>
    /// Model class that represents DbEntity
    /// </summary>
    [Table("Login")]
    public partial class LoginUserModel : INotifyPropertyChanged
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        [StringLength(50)]
        public string PasswordHash
        {
            get { return passwordHash; }
            set
            {
                passwordHash = value;
                NotifyPropertyChanged("PasswordHash");
            }
        }

        private string userName;
        private string passwordHash;

        // INotifyPropertyChanged region
        #region INotifyPropertyChanged region
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged region
    }

    /// <summary>
    /// DbContext class for interaction with DbModel
    /// </summary>
    public partial class LoginDbContext : DbContext
    {
        public LoginDbContext()
            : base("name=Login")
        {
        }

        public virtual DbSet<LoginUserModel> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginUserModel>()
                .Property(e => e.ID);

            modelBuilder.Entity<LoginUserModel>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<LoginUserModel>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);
        }

    }

}
