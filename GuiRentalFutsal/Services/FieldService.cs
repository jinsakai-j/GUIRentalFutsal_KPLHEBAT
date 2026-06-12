using GuiRentalFutsal.Models;

namespace GuiRentalFutsal.Services;

// 'sealed' dihapus
public class FieldService
{
    private readonly JsonDataStore<Field> _store;

    public FieldService(JsonDataStore<Field> store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
    }

    // Tambah 'virtual'
    public virtual List<Field> GetActiveFields()
    {
        return _store.Load()
            .Where(field => field.IsActive)
            .OrderBy(field => field.Id)
            .ToList();
    }

    // Tambah 'virtual'
    public virtual Field? GetById(int id)
    {
        if (id <= 0)
        {
            return null;
        }

        return _store.Load()
            .FirstOrDefault(field => field.Id == id && field.IsActive);
    }

    // Tambah 'virtual'
    public virtual OperationResult<Field> AddField(string name, decimal pricePerHour)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return OperationResult<Field>.Fail("Nama lapangan tidak boleh kosong.");
        }

        if (pricePerHour <= 0)
        {
            return OperationResult<Field>.Fail("Harga per jam harus lebih dari 0.");
        }

        List<Field> fields = _store.Load();

        bool duplicateName = fields.Any(field =>
            field.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));

        if (duplicateName)
        {
            return OperationResult<Field>.Fail("Nama lapangan sudah digunakan.");
        }

        int nextId = fields.Count == 0 ? 1 : fields.Max(field => field.Id) + 1;

        Field newField = new()
        {
            Id = nextId,
            Name = name.Trim(),
            PricePerHour = pricePerHour,
            IsActive = true
        };

        fields.Add(newField);
        _store.Save(fields);

        return OperationResult<Field>.Ok(newField, "Lapangan berhasil ditambahkan.");
    }

    public virtual List<Field> GetAllFields()
    {
        return _store.Load()
            .OrderBy(field => field.Id)
            .ToList();
    }

    public virtual OperationResult<Field> UpdateField(int id, string name, decimal pricePerHour, bool isActive)
    {
        if (id <= 0)
        {
            return OperationResult<Field>.Fail("ID lapangan tidak valid.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return OperationResult<Field>.Fail("Nama lapangan tidak boleh kosong.");
        }

        if (pricePerHour <= 0)
        {
            return OperationResult<Field>.Fail("Harga per jam harus lebih dari 0.");
        }

        List<Field> fields = _store.Load();

        Field? field = fields.FirstOrDefault(f => f.Id == id);

        if (field is null)
        {
            return OperationResult<Field>.Fail("Lapangan tidak ditemukan.");
        }

        bool duplicateName = fields.Any(f =>
            f.Id != id &&
            f.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));

        if (duplicateName)
        {
            return OperationResult<Field>.Fail("Nama lapangan sudah digunakan.");
        }

        field.Name = name.Trim();
        field.PricePerHour = pricePerHour;
        field.IsActive = isActive;

        _store.Save(fields);

        return OperationResult<Field>.Ok(field, "Lapangan berhasil diperbarui.");
    }

    public virtual OperationResult<Field> DeleteField(int id)
    {
        if (id <= 0)
        {
            return OperationResult<Field>.Fail("ID lapangan tidak valid.");
        }

        List<Field> fields = _store.Load();

        Field? field = fields.FirstOrDefault(f => f.Id == id);

        if (field is null)
        {
            return OperationResult<Field>.Fail("Lapangan tidak ditemukan.");
        }

        fields.Remove(field);
        _store.Save(fields);

        return OperationResult<Field>.Ok(field, "Lapangan berhasil dihapus.");
    }
}