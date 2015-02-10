Imports System.Data
Imports System.Data.SqlClient
Public Class frmchinh
    Dim ketnoi As New SqlConnection("data source=csdlqlkh.mssql.somee.com;persist security info=False;initial catalog=csdlqlkh;user id=dunghqpk00294_SQLLogin_1;pwd=s22r9xwvix")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ketnoi.Open()
            Dim makh As String = txtmakh.Text
            Dim tenkh As String = txttenkh.Text
            Dim diachi As String = txtdiachi.Text
            Dim gioitinh As String = txtgt.Text
            Dim sdt As String = txtsdt.Text
            Dim email As String = txtemail.Text
            Dim truyvandl As New SqlCommand("insert into KHACH_HANG(TENKH,DIACHI,GIOITINH,SODIENTHOAI,EMAIL) values (N'" + tenkh + "', N'" + diachi + "', '" + gioitinh + "', '" + sdt + "', '" + email + "')", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangkh()
        Catch ex As Exception
            MessageBox.Show("Không thể thêm dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try

    End Sub

    Private Sub frmchinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ketnoi.Open()
            MessageBox.Show("Kết nối tới CSDL thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ketnoi.Close()
            Loaddulieubangkh()
            Loaddulieubanghd()
            Loaddulieubangcthd()
            Loaddulieubangsp()
            Loaddulieubanglsp()
        Catch ex As Exception
            MessageBox.Show("Kết nối tới CSDL thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
        
    End Sub

    Private Sub Loaddulieubangkh()
        ketnoi.Open()
        Dim truyvandl As New SqlCommand("select * from KHACH_HANG", ketnoi)
        Dim chuyendoidl As New SqlDataAdapter(truyvandl)
        Dim bangdl As New DataTable
        chuyendoidl.Fill(bangdl)

        lsvkh.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In bangdl.Rows
            lsvkh.Items.Add(row("MAKH").ToString())
            lsvkh.Items(i).SubItems.Add(row("TENKH").ToString())
            lsvkh.Items(i).SubItems.Add(row("DIACHI").ToString())
            lsvkh.Items(i).SubItems.Add(row("GIOITINH").ToString())
            lsvkh.Items(i).SubItems.Add(row("SODIENTHOAI").ToString())
            lsvkh.Items(i).SubItems.Add(row("EMAIL").ToString())
            i += 1
        Next
        ketnoi.Close()
    End Sub
    Private Sub Loaddulieubanghd()
        ketnoi.Open()
        Dim truyvandl As New SqlCommand("select * from HOA_DON", ketnoi)
        Dim chuyendoidl As New SqlDataAdapter(truyvandl)
        Dim bangdl As New DataTable
        chuyendoidl.Fill(bangdl)

        lsvhd.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In bangdl.Rows
            lsvhd.Items.Add(row("MAHD").ToString())
            lsvhd.Items(i).SubItems.Add(row("MAKH").ToString())
            lsvhd.Items(i).SubItems.Add(row("NGAYHD").ToString())
            lsvhd.Items(i).SubItems.Add(row("TONGTIEN").ToString())

            i += 1
        Next
        ketnoi.Close()
    End Sub

    Private Sub Loaddulieubangcthd()
        ketnoi.Open()
        Dim truyvandl As New SqlCommand("select * from CHITIET_HOADON", ketnoi)
        Dim chuyendoidl As New SqlDataAdapter(truyvandl)
        Dim bangdl As New DataTable
        chuyendoidl.Fill(bangdl)

        lsvcthd.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In bangdl.Rows
            lsvcthd.Items.Add(row("MACTHD").ToString())
            lsvcthd.Items(i).SubItems.Add(row("MAHD").ToString())
            lsvcthd.Items(i).SubItems.Add(row("MASP").ToString())
            lsvcthd.Items(i).SubItems.Add(row("SOLUONG").ToString())

            i += 1
        Next
        ketnoi.Close()
    End Sub
    Private Sub Loaddulieubangsp()
        ketnoi.Open()
        Dim truyvandl As New SqlCommand("select * from SAN_PHAM", ketnoi)
        Dim chuyendoidl As New SqlDataAdapter(truyvandl)
        Dim bangdl As New DataTable
        chuyendoidl.Fill(bangdl)

        lsvsp.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In bangdl.Rows
            lsvsp.Items.Add(row("MASP").ToString())
            lsvsp.Items(i).SubItems.Add(row("MALSP").ToString())
            lsvsp.Items(i).SubItems.Add(row("TENSP").ToString())
            lsvsp.Items(i).SubItems.Add(row("GIATIEN").ToString())

            i += 1
        Next
        ketnoi.Close()
    End Sub
    Private Sub Loaddulieubanglsp()
        ketnoi.Open()
        Dim truyvandl As New SqlCommand("select * from LOAI_SANPHAM", ketnoi)
        Dim chuyendoidl As New SqlDataAdapter(truyvandl)
        Dim bangdl As New DataTable
        chuyendoidl.Fill(bangdl)

        lsvlsp.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In bangdl.Rows
            lsvlsp.Items.Add(row("MALSP").ToString())
            lsvlsp.Items(i).SubItems.Add(row("TENLSP").ToString())

            i += 1
        Next
        ketnoi.Close()
    End Sub

    Private Sub lsvkh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvkh.SelectedIndexChanged
        For Each ds As ListViewItem In lsvkh.SelectedItems
            txtmakh.Text = ds.SubItems(0).Text
            txttenkh.Text = ds.SubItems(1).Text
            txtdiachi.Text = ds.SubItems(2).Text
            txtgt.Text = ds.SubItems(3).Text
            txtsdt.Text = ds.SubItems(4).Text
            txtemail.Text = ds.SubItems(5).Text
        Next
    End Sub

    Private Sub lsvhd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvhd.SelectedIndexChanged
        For Each ds As ListViewItem In lsvhd.SelectedItems
            txtmakhhd.Text = ds.SubItems(1).Text
            txtmahdhd.Text = ds.SubItems(0).Text
            txtngayhd.Text = ds.SubItems(2).Text
            txttongtien.Text = ds.SubItems(3).Text
        Next
    End Sub

    Private Sub lsvcthd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvcthd.SelectedIndexChanged
        For Each ds As ListViewItem In lsvcthd.SelectedItems
            txtmacthd.Text = ds.SubItems(0).Text
            txtmahdcthd.Text = ds.SubItems(1).Text
            txtmasp.Text = ds.SubItems(2).Text
            txtsl.Text = ds.SubItems(3).Text
        Next
    End Sub

    Private Sub lsvsp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvsp.SelectedIndexChanged
        For Each ds As ListViewItem In lsvsp.SelectedItems
            txtmaspsp.Text = ds.SubItems(0).Text
            txtmalspsp.Text = ds.SubItems(1).Text
            txttensp.Text = ds.SubItems(2).Text
            txtgiatien.Text = ds.SubItems(3).Text
        Next
    End Sub

    Private Sub lsvlsp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvlsp.SelectedIndexChanged
        For Each ds As ListViewItem In lsvlsp.SelectedItems
            txtmalsplsp.Text = ds.SubItems(0).Text
            txttenlsp.Text = ds.SubItems(1).Text
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ketnoi.Open()
            Dim makh As String = txtmakh.Text
            Dim truyvandl As New SqlCommand("delete from KHACH_HANG where MAKH = '" + makh + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangkh()
        Catch ex As Exception
            MessageBox.Show("Không thể xóa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ketnoi.Open()
            Dim makh As String = txtmakh.Text
            Dim tenkh As String = txttenkh.Text
            Dim diachi As String = txtdiachi.Text
            Dim gioitinh As String = txtgt.Text
            Dim sdt As String = txtsdt.Text
            Dim email As String = txtemail.Text
            Dim truyvandl As New SqlCommand("update KHACH_HANG set TENKH = N'" + tenkh + "', DIACHI = N'" + diachi + "', GIOITINH = '" + gioitinh + "', SODIENTHOAI = '" + sdt + "', EMAIL = N'" + email + "'  where makh = '" + makh + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangkh()
        Catch ex As Exception
            MessageBox.Show("Không thể sửa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            ketnoi.Open()
            Dim mahd As String = txtmahdhd.Text
            Dim makh As String = txtmakhhd.Text
            Dim ngayhd As String = txtngayhd.Text
            Dim tongtien As String = txttongtien.Text
            Dim truyvandl As New SqlCommand("insert into HOA_DON(MAKH,NGAYHD,TONGTIEN) values ('" + makh + "', '" + ngayhd + "', '" + tongtien + "')", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanghd()

        Catch ex As Exception
            MessageBox.Show("Không thể thêm dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            ketnoi.Open()
            Dim mahd As String = txtmahdhd.Text
            Dim makh As String = txtmakhhd.Text
            Dim ngayhd As String = txtngayhd.Text
            Dim tongtien As String = txttongtien.Text
            Dim truyvandl As New SqlCommand("update HOA_DON set MAKH = '" + makh + "', NGAYHD = '" + ngayhd + "', TONGTIEN = '" + tongtien + "' where mahd = '" + mahd + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanghd()

        Catch ex As Exception
            MessageBox.Show("Không thể sửa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            ketnoi.Open()
            Dim mahd As String = txtmahdhd.Text
            Dim truyvandl As New SqlCommand("delete from HOA_DON where MAHD = '" + mahd + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanghd()

        Catch ex As Exception
            MessageBox.Show("Không thể xóa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub btnthemcthd_Click(sender As Object, e As EventArgs) Handles btnthemcthd.Click
        Try
            ketnoi.Open()
            Dim macthd As String = txtmacthd.Text
            Dim mahd As String = txtmahdcthd.Text
            Dim masp As String = txtmasp.Text
            Dim soluong As String = txtsl.Text
            Dim truyvandl As New SqlCommand("insert into CHITIET_HOADON(MAHD,MASP,SOLUONG) values ('" + mahd + "', '" + masp + "', '" + soluong + "')", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangcthd()

        Catch ex As Exception
            MessageBox.Show("Không thể thêm dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            ketnoi.Open()
            Dim macthd As String = txtmacthd.Text
            Dim mahd As String = txtmahdcthd.Text
            Dim masp As String = txtmasp.Text
            Dim soluong As String = txtsl.Text
            Dim truyvandl As New SqlCommand("update CHITIET_HOADON set MAHD = '" + mahd + "', MASP = '" + masp + "', SOLUONG = '" + soluong + "' where macthd = '" + macthd + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangcthd()

        Catch ex As Exception
            MessageBox.Show("Không thể sửa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            ketnoi.Open()
            Dim macthd As String = txtmacthd.Text
            Dim truyvandl As New SqlCommand("delete from CHITIET_HOADON where MACTHD = '" + macthd + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangcthd()

        Catch ex As Exception
            MessageBox.Show("Không thể xóa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            ketnoi.Open()
            Dim masp As String = txtmaspsp.Text
            Dim malsp As String = txtmalspsp.Text
            Dim tensp As String = txttensp.Text
            Dim giatien As String = txtgiatien.Text
            Dim truyvandl As New SqlCommand("insert into SAN_PHAM(MALSP,TENSP,GIATIEN) values ('" + malsp + "', '" + tensp + "', '" + giatien + "')", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangsp()

        Catch ex As Exception
            MessageBox.Show("Không thể thêm dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()

        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            ketnoi.Open()
            Dim masp As String = txtmaspsp.Text
            Dim malsp As String = txtmalspsp.Text
            Dim tensp As String = txttensp.Text
            Dim giatien As String = txtgiatien.Text
            Dim truyvandl As New SqlCommand("update SAN_PHAM set MALSP = '" + malsp + "', TENSP = '" + tensp + "', GIATIEN = '" + giatien + "' where masp = '" + masp + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangsp()

        Catch ex As Exception
            MessageBox.Show("Không thể sửa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            ketnoi.Open()
            Dim masp As String = txtmaspsp.Text
            Dim truyvandl As New SqlCommand("delete from SAN_PHAM where MASP = '" + masp + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubangsp()

        Catch ex As Exception
            MessageBox.Show("Không thể xóa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            ketnoi.Open()
            Dim malsp As String = txtmalsplsp.Text
            Dim tenlsp As String = txttenlsp.Text
            Dim truyvandl As New SqlCommand("insert into LOAI_SANPHAM(TENLSP) values ( N'" + tenlsp + "')", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanglsp()

        Catch ex As Exception
            MessageBox.Show("Không thể thêm dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()

        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            ketnoi.Open()
            Dim malsp As String = txtmalsplsp.Text
            Dim tenlsp As String = txttenlsp.Text
            Dim truyvandl As New SqlCommand("update LOAI_SANPHAM set TENLSP = N'" + tenlsp + "' where MALSP = N'" + malsp + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanglsp()

        Catch ex As Exception
            MessageBox.Show("Không thể sửa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Try
            ketnoi.Open()
            Dim malsp As String = txtmalsplsp.Text
            Dim truyvandl As New SqlCommand("delete from LOAI_SANPHAM where MALSP = N'" + malsp + "'", ketnoi)
            truyvandl.ExecuteNonQuery()
            ketnoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Loaddulieubanglsp()

        Catch ex As Exception
            MessageBox.Show("Không thể xóa dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ketnoi.Close()
        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        DialogResult = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        DialogResult = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        DialogResult = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        DialogResult = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DialogResult = MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (DialogResult = Windows.Forms.DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub
End Class